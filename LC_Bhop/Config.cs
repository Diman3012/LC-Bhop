using BepInEx.Configuration;

namespace lcbhop
{
    public class Config
    {
        private readonly ConfigFile config;

        public ConfigEntry<bool> modEnabled; 
        public ConfigEntry<bool> autobhop;
        public ConfigEntry<bool> speedometer;
        public ConfigEntry<bool> enablebunnyhopping;

        public ConfigEntry<float> gravity;
        public ConfigEntry<float> friction;
        public ConfigEntry<float> maxspeed;
        public ConfigEntry<float> movespeed;
        public ConfigEntry<float> accelerate;
        public ConfigEntry<float> airaccelerate;
        public ConfigEntry<float> stopspeed;

        public Config(ConfigFile cfg)
        {
            config = cfg;
        }

        public void Init()
        {
            modEnabled = config.Bind("General", "ModEnabled", false, "Глобальный переключатель мода.");
            autobhop = config.Bind("General", "Auto Bhop", true, "Авто-прыжок при зажатом пробеле.");
            speedometer = config.Bind("General", "Speedometer", false, "Спидометр.");
            
            // Версия v4: лимит 1500 и ускорение 150
            enablebunnyhopping = config.Bind("Movement v4", "Enable bunnyhopping", true, "Отключение лимита скорости.");
            gravity = config.Bind("Movement v4", "Gravity", 800.0f, "Гравитация.");
            friction = config.Bind("Movement v4", "Friction", 4.0f, "Трение.");
            maxspeed = config.Bind("Movement v4", "Max Speed", 1500.0f, "Максимальный лимит (1500).");
            movespeed = config.Bind("Movement v4", "Move Speed", 250.0f, "Базовая скорость.");
            accelerate = config.Bind("Movement v4", "Accelerate", 5.0f, "Ускорение на земле.");
            
            // Увеличили со 100 до 150 для более быстрого набора
            airaccelerate = config.Bind("Movement v4", "Air Accelerate", 150.0f, "Ускорение в воздухе.");
            stopspeed = config.Bind("Movement v4", "Stop Speed", 75.0f, "Скорость остановки.");
        }
    }
}