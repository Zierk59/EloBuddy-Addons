﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Harass
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _HarassWithQ;

        public static bool HarassWithQ
        {
            get { return _HarassWithQ.CurrentValue; }
        }

        static Harass()
        {
            Menu = Config.Menu.AddSubMenu("Harass");
            Menu.AddGroupLabel("Harass settings");
            _HarassWithQ = Menu.Add("HarasWithQ", new CheckBox("Enable auto Q in harass mode."));
        }

        public static void Initialize()
        {
        }
    }
}