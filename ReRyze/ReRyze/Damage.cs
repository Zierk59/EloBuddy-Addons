using EloBuddy;
using EloBuddy.SDK;
using System;

namespace ReRyze
{
    class Damage
    {
        public static readonly Random getrandom = new Random();
        public static readonly int[] UltimateRange = { 1500, 3000 };

        public static double GetQDamage(Obj_AI_Base target)
        {
            if (SpellManager.Q.IsReady())
                return Player.Instance.GetSpellDamage(target, SpellSlot.Q, DamageLibrary.SpellStages.Default);
            return 0;
        }

        public static double GetWDamage(Obj_AI_Base target)
        {
            if (SpellManager.W.IsLearned)
                return Player.Instance.GetSpellDamage(target, SpellSlot.W, DamageLibrary.SpellStages.Default);
            return 0;
        }

        public static double GetEDamage(Obj_AI_Base target)
        {
            if (SpellManager.E.IsReady())
                return Player.Instance.GetSpellDamage(target, SpellSlot.E, DamageLibrary.SpellStages.Default);
            return 0;
        }

        public static double GetRDamage(Obj_AI_Base target)
        {
            if (SpellManager.R.IsReady())
                return Player.Instance.GetSpellDamage(target, SpellSlot.R, DamageLibrary.SpellStages.Default);
            return 0;
        }

        public static float GetIgniteDamage()
        {
            if (SummonersManager.Ignite.IsReady() && SummonersManager.PlayerHasIgnite)
                return 50 + (Player.Instance.Level * 20);
            return 0;
        }

        public static double GetTotalDamage(Obj_AI_Base target)
        {
            var damage = 0.0;
            damage += GetQDamage(target);
            damage += GetWDamage(target);
            damage += GetEDamage(target);
            damage += GetRDamage(target);
            damage += GetIgniteDamage();
            damage += Player.Instance.GetAutoAttackDamage(target, true);
            return damage;
        }

        public static int GetAditionalDelay()
        {
            return getrandom.Next(0, (ConfigList.Misc.GetMaxAditDelay));
        }
    }
}