using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class Flee
    {
        public static void Execute()
        {
            if (!ConfigList.Misc.FleeWithEWQ)
                return;

            int delay = ConfigList.Misc.GetSpellDelay + Damage.GetAditionalDelay();
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            if (SpellManager.E.IsReady())
                SpellManager.E.Cast(target);

            if (SpellManager.W.IsReady())
                Core.DelayAction(() => SpellManager.W.Cast(target), delay);

            if (SpellManager.Q.IsReady())
            {
                var predQ = SpellManager.Q.GetPrediction(target);
                if (predQ.HitChance >= HitChance.Low)
                    Core.DelayAction(() => SpellManager.Q.Cast(predQ.CastPosition), delay * 2);
            }
        }
    }
}