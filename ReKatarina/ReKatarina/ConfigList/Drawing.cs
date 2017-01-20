﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Drawing
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _drawQ;
        private static readonly CheckBox _drawW;
        private static readonly CheckBox _drawE;
        private static readonly CheckBox _drawR;
        private static readonly CheckBox _drawDI;
        private static readonly CheckBox _drawCJ;
        private static readonly CheckBox _drawDagger;

        public static bool DrawQ
        {
            get { return _drawQ.CurrentValue; }
        }

        public static bool DrawW
        {
            get { return _drawW.CurrentValue; }
        }

        public static bool DrawE
        {
            get { return _drawE.CurrentValue; }
        }

        public static bool DrawR
        {
            get { return _drawR.CurrentValue; }
        }

        public static bool DrawDI
        {
            get { return _drawDI.CurrentValue; }
        }
        public static bool DrawCJ
        {
            get { return _drawCJ.CurrentValue; }
        }
        public static bool DrawDagger
        {
            get { return _drawDagger.CurrentValue; }
        }

        static Drawing()
        {
            Menu = Config.Menu.AddSubMenu("Drawing");
            Menu.AddGroupLabel("Drawing settings");
            _drawQ = Menu.Add("Drawing.DrawQ", new CheckBox("Draw Q range", false));
            _drawW = Menu.Add("Drawing.DrawW", new CheckBox("Draw W range", false));
            _drawE = Menu.Add("Drawing.DrawE", new CheckBox("Draw E range"));
            _drawR = Menu.Add("Drawing.DrawR", new CheckBox("Draw R range", false));
            _drawDagger = Menu.Add("Drawing.DrawDagger", new CheckBox("Draw daggers"));
            Menu.AddGroupLabel("Damage indicator");
            _drawDI = Menu.Add("Drawing.DamageIndicator", new CheckBox("Draw Damage Indicator"));
            Menu.AddGroupLabel("Cursor jump range");
            _drawCJ = Menu.Add("Drawing.Cursor", new CheckBox("Draw circle around mouse with range of flee / ward jump."));
        }

        public static void Initialize()
        {
        }
    }
}