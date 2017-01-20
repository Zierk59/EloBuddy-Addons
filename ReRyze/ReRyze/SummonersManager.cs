using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using System.Collections.Generic;

namespace ReRyze
{
    public static class SummonersManager
    {
        public static Spell.Targeted Ignite { get; private set; }
        public static bool PlayerHasIgnite = false;

        public static Spell.Targeted Exhaust { get; private set; }
        public static bool PlayerHasExhaust = false;

        public static Spell.Active Barrier { get; private set; }
        public static bool PlayerHasBarrier = false;

        static SummonersManager()
        {
            Ignite = new Spell.Targeted(Player.Instance.FindSummonerSpellSlotFromName("ignite"), 600);
            if (Player.Instance.FindSummonerSpellSlotFromName("ignite") != SpellSlot.Unknown)
                PlayerHasIgnite = true;

            Exhaust = new Spell.Targeted(Player.Instance.FindSummonerSpellSlotFromName("exhaust"), 650);
            if (Player.Instance.FindSummonerSpellSlotFromName("exhaust") != SpellSlot.Unknown)
                PlayerHasExhaust = true;

            Barrier = new Spell.Active(Player.Instance.FindSummonerSpellSlotFromName("barrier"));
            if (Player.Instance.FindSummonerSpellSlotFromName("barrier") != SpellSlot.Unknown)
                PlayerHasBarrier = true;
        }
    }
}