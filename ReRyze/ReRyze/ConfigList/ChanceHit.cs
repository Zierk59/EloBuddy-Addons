using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class ChanceHit
    {
        private static readonly Menu Menu;
        private static readonly Slider _ComboMinToUseQ;
        private static readonly Slider _LCMinToUseQ;
        private static readonly Slider _HarassMinToUseQ;
        private static readonly Slider _AutoHarassMinToUseQ;

        public static int ComboMinToUseQ
        {
            get { return _ComboMinToUseQ.CurrentValue; }
        }

        public static int LaneClearMinToUseQ
        {
            get { return _LCMinToUseQ.CurrentValue; }
        }

        public static int HarassMinToUseQ
        {
            get { return _HarassMinToUseQ.CurrentValue; }
        }

        public static int AutoHarassMinToUseQ
        {
            get { return _AutoHarassMinToUseQ.CurrentValue; }
        }

        public static HitChance GetHitChance(int num)
        {
            switch (num)
            {
                case 1: return HitChance.Low;
                case 2: return HitChance.Medium;
                case 3: return HitChance.High;
            }
            return HitChance.Medium;
        }
        static ChanceHit()
        {
            Menu = Config.Menu.AddSubMenu("Hit chance");
            Menu.AddGroupLabel("Hit chance settings");
            Menu.AddLabel("HitChance : 1 = Low, 2 = Medium, 3 = High");
            _ComboMinToUseQ = Menu.Add("MinToUseQ", new Slider("Hit chance to use Q in combo.", 2, 1, 3));
            _LCMinToUseQ = Menu.Add("LCMinToUseQ", new Slider("Hit chance to use Q in lane clear.", 1, 1, 3));
            _HarassMinToUseQ = Menu.Add("HarassMinToUseQ", new Slider("Hit chance to use Q in harass mode.", 2, 1, 3));
            _AutoHarassMinToUseQ = Menu.Add("AutoHarassMinToUseQ", new Slider("Hit chance to use Q in auto harass.", 1, 1, 3));
        }

        public static void Initialize()
        {
        }
    }
}