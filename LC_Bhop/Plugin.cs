using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.Linq; // Добавлено для работы Aggregate
using Unity.Netcode;

namespace lcbhop
{
    public class ComponentAdder : MonoBehaviour
    {
        void Update()
        {
            foreach (PlayerControllerB playerControllerB in UnityEngine.Object.FindObjectsOfType<PlayerControllerB>())
            {
                if (playerControllerB != null && playerControllerB.gameObject.GetComponentInChildren<CPMPlayer>() == null && playerControllerB.IsOwner && playerControllerB.isPlayerControlled)
                {
                    Plugin.player = playerControllerB.gameObject.AddComponent<CPMPlayer>();
                    Plugin.player.player = playerControllerB;
                }
            }
        }
    }

    [BepInPlugin("lcbhop", "LC Bhop", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource logger;
        private readonly Harmony harmony = new Harmony("lcbhop");
        public static Config cfg { get; set; }
        public static bool patchMove = true;
        public static bool patchJump = true;
        public static CPMPlayer player;

        void Awake()
        {
            cfg = new Config(Config);
            cfg.Init();
            logger = Logger;
            harmony.PatchAll();
            Logger.LogInfo($"Plugin lcbhop is loaded!");
        }

        void OnDestroy()
        {
            GameObject gameObject = new GameObject("ComponentAdder");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<ComponentAdder>();
        }
    }

    // Внедренный патч для регистрации сетевого префаба
    [HarmonyPatch(typeof(NetworkManager))]
    internal static class NetworkPrefabPatch2
    {
        // Используем ту же строку, что и в BepInPlugin
        private static readonly string MOD_GUID = "lcbhop";

        [HarmonyPostfix]
        [HarmonyPatch(nameof(NetworkManager.SetSingleton))]
        private static void RegisterPrefab()
        {
            var prefab = new GameObject(MOD_GUID + " Prefab");
            prefab.hideFlags |= HideFlags.HideAndDontSave;
            Object.DontDestroyOnLoad(prefab);
            var networkObject = prefab.AddComponent<NetworkObject>();

            var fieldInfo = typeof(NetworkObject).GetField("GlobalObjectIdHash", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(networkObject, GetHash(MOD_GUID));
            }

            if (NetworkManager.Singleton != null && NetworkManager.Singleton.PrefabHandler != null)
            {
                NetworkManager.Singleton.PrefabHandler.AddNetworkPrefab(prefab);
            }
        }

        private static uint GetHash(string value)
        {
            return value?.Aggregate(17u, (current, c) => unchecked((current * 31) ^ (uint)c)) ?? 0u;
        }
    }
}