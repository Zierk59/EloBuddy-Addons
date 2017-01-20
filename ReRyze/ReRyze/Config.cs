using EloBuddy.SDK.Menu;
using ReRyze.ConfigList;

namespace ReRyze
{
    public static class Config
    {
        public static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu("ReRyze", "ReRyze");
            Menu.AddGroupLabel("Welcome to ReRyze! Please report all bugs.");
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            static Modes()
            {
                // Menu
                Combo.Initialize();
                Farm.Initialize();
                Harass.Initialize();
                Drawing.Initialize();
                UltimateTeleport.Initialize();
                ChanceHit.Initialize();
                ManaManager.Initialize();
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }
        }
    }
}