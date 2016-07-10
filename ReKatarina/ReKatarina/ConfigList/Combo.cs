﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Combo
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _ComboQ;
        private static readonly CheckBox _ComboW;
        private static readonly CheckBox _ComboE;
        private static readonly CheckBox _ComboR;
        private static readonly Slider _MinToUseR;
        private static readonly Slider _MaxRCastRange;
        private static readonly CheckBox _GoUnderTower;

        public static bool ComboQ
        {
            get { return _ComboQ.CurrentValue; }
        }
        public static bool ComboW
        {
            get { return _ComboW.CurrentValue; }
        }
        public static bool ComboE
        {
            get { return _ComboE.CurrentValue; }
        }
        public static bool ComboR
        {
            get { return _ComboR.CurrentValue; }
        }
        public static int MinToUseR
        {
            get { return _MinToUseR.CurrentValue; }
        }
        public static int MaxRCastRange
        {
            get { return _MaxRCastRange.CurrentValue; }
        }
        public static bool GoUnderTower
        {
            get { return _GoUnderTower.CurrentValue; }
        }

        static Combo()
        {
            Menu = Config.Menu.AddSubMenu("Combo");
            Menu.AddGroupLabel("Combo settings");
            _ComboQ = Menu.Add("ComboQ", new CheckBox("Use Q in combo"));
            _ComboW = Menu.Add("ComboW", new CheckBox("Use W in combo"));
            _ComboE = Menu.Add("ComboE", new CheckBox("Use E in combo"));
            _ComboR = Menu.Add("ComboR", new CheckBox("Use R in combo"));
            Menu.AddGroupLabel("R settings");
            _MinToUseR = Menu.Add("MinToUseR", new Slider("Minimum enemies to use R.", 1, 1, 5));
            _MaxRCastRange = Menu.Add("MaxRCastRange", new Slider("Maximum R range to cast.", (int)SpellManager.W.Range, (int)SpellManager.W.Range, (int)SpellManager.R.Range));
            _GoUnderTower = Menu.Add("GoUnderTower", new CheckBox("Allow E jump under enemy turret.", false));
        }

        public static void Initialize()
        {
        }
    }
}