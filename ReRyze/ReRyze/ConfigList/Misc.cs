using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Misc
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _KSWithQ;
        private static readonly CheckBox _KSWithW;
        private static readonly CheckBox _KSWithE;

        private static readonly CheckBox _GapClose;
        private static readonly CheckBox _FleeWithEWQ;

        private static readonly CheckBox _SkinManagerStatus;
        private static readonly Slider _SkinManager;
        private static readonly Slider _Delay;
        private static readonly Slider _MaxRandomDelay;

        public static bool KSWithQ
        {
            get { return _KSWithQ.CurrentValue; }
        }
        public static bool KSWithW
        {
            get { return _KSWithW.CurrentValue; }
        }
        public static bool KSWithE
        {
            get { return _KSWithE.CurrentValue; }
        }
        public static bool FleeWithEWQ
        {
            get { return _FleeWithEWQ.CurrentValue; }
        }
        public static bool GetSkinManagerStatus
        {
            get { return _SkinManagerStatus.CurrentValue; }
        }
        public static int GetSkinManager
        {
            get { return _SkinManager.CurrentValue; }
        }
        public static int GetSpellDelay
        {
            get { return _Delay.CurrentValue; }
        }
        public static int GetMaxAditDelay
        {
            get { return _MaxRandomDelay.CurrentValue; }
        }
        public static bool GapCloser
        {
            get { return _GapClose.CurrentValue; }
        }

        static Misc()
        {
            Menu = Config.Menu.AddSubMenu("Misc");
            Menu.AddGroupLabel("Misc settings");
            _KSWithQ = Menu.Add("KSWithQ", new CheckBox("Enable Kill Steal with Q."));
            _KSWithW = Menu.Add("KSWithW", new CheckBox("Enable Kill Steal with W."));
            _KSWithE = Menu.Add("KSWithE", new CheckBox("Enable Kill Steal with E."));
            _GapClose = Menu.Add("GapClose", new CheckBox("Enable gap-close with W."));
            _FleeWithEWQ = Menu.Add("FleeWithEWQ", new CheckBox("Enable EWQ in flee mode."));

            Menu.AddGroupLabel("Skin manager");
            _SkinManagerStatus = Menu.Add("SkinManagerStatus", new CheckBox("Enable skin changer."));
            _SkinManager = Menu.Add("SkinManager", new Slider("Select your skin.", 1, 0, 10));

            Menu.AddGroupLabel("Humanizer");
            _Delay = Menu.Add("Delay", new Slider("Select your delay between spells in (ms).", 150, 100, 500));
            _MaxRandomDelay = Menu.Add("MaxRandomDelay", new Slider("Additional random delay in (ms).", 75, 50, 100));
        }

        public static void Initialize()
        {
        }
    }
}