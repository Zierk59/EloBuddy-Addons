using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Harass
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _HarassWithQ;
        private static readonly CheckBox _HarassWithE;
        private static readonly CheckBox _AutoHarassWithQ;
        private static readonly Slider _AutoHarassChance;
        private static readonly CheckBox _AutoHarassUnderTurret;

        public static bool HarassWithQ
        {
            get { return _HarassWithQ.CurrentValue; }
        }
        public static bool HarassWithE
        {
            get { return _HarassWithE.CurrentValue; }
        }

        public static bool AutoHarassWithQ
        {
            get { return _AutoHarassWithQ.CurrentValue; }
        }
        public static int AutoHarassChance
        {
            get { return _AutoHarassChance.CurrentValue; }
        }
        public static bool AutoHarassUnderTurret
        {
            get { return _AutoHarassUnderTurret.CurrentValue; }
        }

        static Harass()
        {
            Menu = Config.Menu.AddSubMenu("Harass");
            Menu.AddGroupLabel("Harass settings");
            _HarassWithQ = Menu.Add("HarasWithQ", new CheckBox("Enable Q in harass mode."));
            _HarassWithE = Menu.Add("HarasWithE", new CheckBox("Enable E in harass mode."));
            Menu.AddGroupLabel("Auto-harass settings");
            _AutoHarassWithQ = Menu.Add("AutoHarassWithQ", new CheckBox("Enable auto harass with Q."));
            _AutoHarassChance = Menu.Add("AutoHarassChance", new Slider("Auto harass chance.", 50, 1, 100));
            _AutoHarassUnderTurret = Menu.Add("AutoHarassUnderTurret", new CheckBox("Allow to auto harass under enemy turret.", false));
        }

        public static void Initialize()
        {
        }
    }
}