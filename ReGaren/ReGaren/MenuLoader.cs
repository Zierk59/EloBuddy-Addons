﻿using EloBuddy.SDK.Menu;
using ReGaren.Config;

namespace ReGaren
{
    public static class MenuLoader
    {
        public static readonly Menu Menu;

        static MenuLoader()
        {
            Menu = MainMenu.AddMenu("ReGaren", "ReGaren");
            Menu.AddGroupLabel("Welcome to ReGaren!");
            Utility.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Utility
        {
            static Utility()
            {
                // Menu
                Combo.Initialize();
                Drawing.Initialize();
                Farm.Initialize();
                Harass.Initialize();
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }
        }
    }
}