using EloBuddy;
using EloBuddy.SDK;

namespace ReRyze.Utility
{
    public static class Harass
    {
        public static void Execute()
        {
            if (!SpellManager.Q.IsReady() && SpellManager.E.IsReady())
                return;

            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            if (ConfigList.Harass.HarassWithE && SpellManager.E.IsReady())
                SpellManager.E.Cast(target);

            if (!ConfigList.Harass.HarassWithQ || !SpellManager.Q.IsReady())
                return;

            var predQ = SpellManager.Q.GetPrediction(target);
            if (predQ.HitChance >= ConfigList.ChanceHit.GetHitChance(ConfigList.ChanceHit.HarassMinToUseQ))
            {
                SpellManager.Q.Cast(predQ.CastPosition);
            }
        }
    }
}