using System.Reflection;
using GameNetcodeStuff;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace lcbhop
{
    struct Cmd
    {
        public float forwardMove;
        public float rightMove;
        public float upMove;
    }

    public class CPMPlayer : MonoBehaviour
    {
        // Читаем значения через .Value
        public float gravity => Plugin.cfg.gravity.Value;
        public float friction => Plugin.cfg.friction.Value;
        public float maxspeed => Plugin.cfg.maxspeed.Value;
        public float movespeed => Plugin.cfg.movespeed.Value;
        public float accelerate => Plugin.cfg.accelerate.Value;
        public float airaccelerate => Plugin.cfg.airaccelerate.Value;
        public float stopspeed => Plugin.cfg.stopspeed.Value;

        public PlayerControllerB player;
        private CharacterController _controller;
        private Vector3 velocity = Vector3.zero;
        public bool wishJump = false;
        private Cmd _cmd;
        private GameObject compass;
        private TextMeshProUGUI speedo;

        private void Start()
        {
            _controller = player.thisController;
        }

        private void Update()
        {
            if (Keyboard.current.f1Key.wasPressedThisFrame)
            {
                Plugin.cfg.modEnabled.Value = !Plugin.cfg.modEnabled.Value;
                HUDManager.Instance?.DisplayTip("LC Bhop", Plugin.cfg.modEnabled.Value ? "Enabled" : "Disabled");

                if (!Plugin.cfg.modEnabled.Value)
                {
                    Plugin.patchMove = false;
                    Plugin.patchJump = false;
                    if (compass) compass.SetActive(false);
                }
            }

            if (!Plugin.cfg.modEnabled.Value) return;

            player.fallValue = 0.0f;
            player.fallValueUncapped = 0.0f;
            player.sprintMeter = 1.0f;

            if ((!player.IsOwner || !player.isPlayerControlled || (player.IsServer && !player.isHostPlayerObject)) && !player.isTestingPlayer)
            {
                return;
            }
            if (player.quickMenuManager.isMenuOpen || player.inSpecialInteractAnimation || player.isTypingChat)
            {
                return;
            }

            if (player.isClimbingLadder)
            {
                Plugin.patchMove = false;
                return;
            }

            Jump();

            if (!wishJump && _controller.isGrounded)
                Friction();

            if (_controller.isGrounded)
                WalkMove();
            else if (!_controller.isGrounded)
                AirMove();

            Plugin.patchMove = false;
            _controller.Move(velocity / 32.0f * Time.deltaTime);
            Plugin.patchMove = true;

            wishJump = false;

            /* Speedometer */
            if (Plugin.cfg.speedometer.Value)
            {
                if (!compass)
                {
                    compass = GameObject.Find("/Systems/UI/Canvas/IngamePlayerHUD/TopLeftCorner/Compass");
                    speedo = compass?.GetComponentInChildren<TextMeshProUGUI>();
                }
                if (!compass) return;

                compass.SetActive(true);
                Vector3 vel = velocity;
                vel.y = 0.0f;
                speedo.text = $"{(int)vel.magnitude} u";
                speedo.rectTransform.sizeDelta = speedo.GetPreferredValues();
            }
            else
            {
                if (compass) compass.SetActive(false);
            }
        }

        private void SetMovementDir()
        {
            _cmd.forwardMove = player.playerActions.Movement.Move.ReadValue<Vector2>().y * movespeed;
            _cmd.rightMove = player.playerActions.Movement.Move.ReadValue<Vector2>().x * movespeed;
        }

        private void Jump()
        {
            if (Plugin.cfg.autobhop.Value)
                wishJump = player.playerActions.Movement.Jump.ReadValue<float>() > 0.0f;
            else
            {
                if (!wishJump)
                    wishJump = player.playerActions.Movement.SwitchItem.ReadValue<float>() != 0.0f;
            }

            // Проверяем конфиг, если включен баннихоп - не тормозим игрока
            if (!Plugin.cfg.enablebunnyhopping.Value)
                PreventMegaBunnyJumping();
        }

        private void AirMove()
        {
            Vector3 wishvel;
            Vector3 wishdir;
            float wishspeed;

            SetMovementDir();
            wishvel = new Vector3(_cmd.rightMove, 0, _cmd.forwardMove);
            wishvel = transform.TransformDirection(wishvel);
            wishdir = wishvel;
            wishspeed = wishdir.magnitude;
            wishdir.Normalize();

            if (wishspeed > maxspeed)
            {
                wishspeed = maxspeed;
            }

            AirAccelerate(wishdir, wishspeed, airaccelerate);
            velocity.y -= gravity * Time.deltaTime;
        }

        private void AirAccelerate(Vector3 wishdir, float wishspeed, float accel)
        {
            float addspeed, accelspeed, currentspeed;

            // КЛЮЧЕВОЕ ИЗМЕНЕНИЕ: 
            // Ограничение wishspd до 30 — это "золотой стандарт" HL. 
            // Именно это делает разгон плавным, а не мгновенным.
            float wishspd = wishspeed;
            if (wishspd > 75f) wishspd = 75f;

            currentspeed = Vector3.Dot(velocity, wishdir);
            addspeed = wishspd - currentspeed;

            if (addspeed <= 0) return;

            accelspeed = accel * wishspeed * Time.deltaTime;

            if (accelspeed > addspeed) accelspeed = addspeed;

            velocity.x += accelspeed * wishdir.x;
            velocity.z += accelspeed * wishdir.z;

            // Жесткое ограничение итоговой горизонтальной скорости до 1500
            Vector3 horizVel = new Vector3(velocity.x, 0, velocity.z);
            if (horizVel.magnitude > maxspeed)
            {
                horizVel = horizVel.normalized * maxspeed;
                velocity.x = horizVel.x;
                velocity.z = horizVel.z;
            }
        }
        private void WalkMove()
        {
            Vector3 wishvel;
            Vector3 wishdir;
            float wishspeed;

            SetMovementDir();
            wishvel = new Vector3(_cmd.rightMove, 0, _cmd.forwardMove);
            wishvel = transform.TransformDirection(wishvel);
            wishdir = wishvel;
            wishspeed = wishdir.magnitude;
            wishdir.Normalize();

            if (wishspeed > maxspeed)
            {
                wishvel *= maxspeed / wishspeed;
                wishspeed = maxspeed;
            }

            Accelerate(wishdir, wishspeed, accelerate);
            velocity.y = -gravity * Time.deltaTime;

            if (wishJump)
            {
                velocity.y = 295; // Сила прыжка
            }
        }

        private void Friction()
        {
            Vector3 vec = velocity;
            float speed, newspeed, control, drop;
            vec.y = 0.0f;
            speed = vec.magnitude;

            if (speed < 0.1f) return;
            drop = 0.0f;

            if (_controller.isGrounded)
            {
                control = (speed < stopspeed) ? stopspeed : speed;
                drop += control * friction * Time.deltaTime;
            }

            newspeed = speed - drop;
            if (newspeed < 0) newspeed = 0;
            newspeed /= speed;

            velocity.x *= newspeed;
            velocity.z *= newspeed;
        }

        private void Accelerate(Vector3 wishdir, float wishspeed, float accel)
        {
            float addspeed, accelspeed, currentspeed;
            currentspeed = Vector3.Dot(velocity, wishdir);
            addspeed = wishspeed - currentspeed;
            if (addspeed <= 0) return;
            accelspeed = accel * Time.deltaTime * wishspeed;
            if (accelspeed > addspeed) accelspeed = addspeed;
            velocity.x += accelspeed * wishdir.x;
            velocity.z += accelspeed * wishdir.z;
        }

        private void PreventMegaBunnyJumping()
        {
            Vector3 vec = velocity;
            float spd, fraction, maxscaledspeed;
            maxscaledspeed = 1.7f * maxspeed;
            if (maxscaledspeed <= 0.0f) return;
            vec.y = 0.0f;
            spd = vec.magnitude;
            if (spd <= maxscaledspeed) return;
            fraction = (maxscaledspeed / spd) * 0.65f;
            velocity.x *= fraction;
            velocity.z *= fraction;
        }
    }
}