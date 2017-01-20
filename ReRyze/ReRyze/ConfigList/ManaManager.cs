using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class ManaManager
    {
        private static readonly Menu Menu;
        private static readonly Slider _LCUseQ;
        private static readonly Slider _LCUseE;
        private static readonly Slider _LHUseQ;
        private static readonly Slider _AutoHarassUseQ;

        public static int LaneClearQ_Mana
        {
            get { return _LCUseQ.CurrentValue; }
        }
        public static int LaneClearE_Mana
        {
            get { return _LCUseE.CurrentValue; }
        }
        public static int LastHitQ_Mana
        {
            get { return _LHUseQ.CurrentValue; }
        }
        public static int AutoHarassQ_Mana
        {
            get { return _AutoHarassUseQ.CurrentValue; }
        }

        static ManaManager()
        {
            Menu = Config.Menu.AddSubMenu("Mana manager");
            Menu.AddGroupLabel("Mana manager settings");
            Menu.AddSeparator(15);
            Menu.AddGroupLabel("Lane / jungle clear");
            _LCUseQ = Menu.Add("LCUseQ", new Slider("Use Q if my mana is more than {0}%.", 50, 1, 100));
            _LCUseE = Menu.Add("LCUseW", new Slider("Use W if my mana is more than {0}%.", 50, 1, 100));

            Menu.AddGroupLabel("Last hit");
            _LHUseQ = Menu.Add("LHUseQ", new Slider("Use Q if my mana is more than {0}%.", 65, 1, 100));

            Menu.AddGroupLabel("Auto harass");
            _AutoHarassUseQ = Menu.Add("AutoHarassUseQ", new Slider("Use Q if my mana is more than {0}%.", 75, 1, 100));
        }

        public static void Initialize()
        {
        }
    }
}