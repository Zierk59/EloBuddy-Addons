using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using System;

namespace ReRyze.Utility
{
    public static class PermaActive
    {
        private static bool chance(int chance)
        {
            if (Damage.getrandom.Next(0, 100) <= chance)
                return true;
            return false;
        }

        public static void Execute()
        {
            if (Environment.TickCount - SpellManager.LastCombo > 3000)
                SpellManager.ComboStep = 0;

            // Auto range update
            if (SpellManager.R.Level >= 2 && SpellManager.R.Range == Damage.UltimateRange[0])
                SpellManager.R.Range = (uint)Damage.UltimateRange[1];

            // Skin manager
            if (ConfigList.Misc.GetSkinManagerStatus && Player.Instance.SkinId != ConfigList.Misc.GetSkinManager)
            {
                Player.Instance.SetSkinId(ConfigList.Misc.GetSkinManager);
            }

            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target != null && target.IsValid())
            {
                // Auto KS
                if (target.HealthPercent >= 15.0)
                {
                    if (SpellManager.Q.IsReady() && ConfigList.Misc.KSWithQ && Damage.GetQDamage(target) - 5 >= target.TotalShieldHealth())
                    {
                        var predQ = SpellManager.Q.GetPrediction(target);
                        if (predQ.HitChance >= HitChance.Medium)
                        {
                            SpellManager.Q.Cast(predQ.CastPosition); return;
                        }
                    }
                    if (SpellManager.W.IsReady() && ConfigList.Misc.KSWithW && Damage.GetWDamage(target) - 5 >= target.TotalShieldHealth())
                    {
                        SpellManager.W.Cast(target);
                        return;
                    }
                    if (SpellManager.E.IsReady() && ConfigList.Misc.KSWithE && Damage.GetEDamage(target) - 5 >= target.TotalShieldHealth())
                        SpellManager.E.Cast(target);
                }

                // Auto harass
                if (Environment.TickCount - SpellManager.LastAutoHarass < 1500 && ConfigList.Harass.AutoHarassWithQ)
                {
                    if (!ConfigList.Harass.AutoHarassUnderTurret && Player.Instance.IsUnderEnemyturret() && target.IsUnderHisturret())
                        return;

                    if (!chance(ConfigList.Harass.AutoHarassChance))
                        return;

                    if (SpellManager.Q.IsReady() && Player.Instance.ManaPercent >= ConfigList.ManaManager.AutoHarassQ_Mana)
                    {
                        var predQ = SpellManager.Q.GetPrediction(target);
                        if (predQ.HitChance >= ConfigList.ChanceHit.GetHitChance(ConfigList.ChanceHit.AutoHarassMinToUseQ))
                        {
                            SpellManager.LastAutoHarass = Environment.TickCount;
                            SpellManager.Q.Cast(predQ.CastPosition); return;
                        }
                    }
                }
            }
        }
    }
}
