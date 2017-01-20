using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class UltimateTeleport
    {
        private static readonly Menu Menu;
        private static readonly KeyBind _TPUltKey;
        private static readonly Slider _MinAllyToTP;
        private static readonly Slider _MinEnemyToTP;

        public static bool TeleportKey { get { return _TPUltKey.CurrentValue; } }
        public static int MinAllyToTP { get { return _MinAllyToTP.CurrentValue; } }
        public static int MinEnemyToTP { get { return _MinEnemyToTP.CurrentValue; } }

        static UltimateTeleport()
        {
            Menu = Config.Menu.AddSubMenu("Ultimate");
            Menu.AddGroupLabel("Ultimate settings");

            _TPUltKey = Menu.Add("TPUltKey", new KeyBind("Ult usage key", false, KeyBind.BindTypes.HoldActive, 'G'));
            _MinAllyToTP = Menu.Add("MinAllyToTP", new Slider("Min allies to use ultimate.", 1, 0, 4));
            _MinEnemyToTP = Menu.Add("MinEnemyToTP", new Slider("Min enemies to use ultimate.", 2, 1, 5));
        }

        public static void Initialize()
        {
        }
    }
}