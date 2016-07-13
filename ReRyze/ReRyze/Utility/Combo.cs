﻿using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using ReRyze.ConfigList;

namespace ReRyze.Utility
{
    public static class Combo
    {
        private static int LastCombo = 0;
        public static void Execute()
        {
            if (!ReRyze.ConfigList.Combo.ComboWithoutQ && !SpellManager.Q.IsReady() && Environment.TickCount - LastCombo < 2500)
                return;

            LastCombo = Environment.TickCount;
            var target = TargetSelector.GetTarget(SpellManager.Q.Range - 50, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            if (SpellManager.Q.IsReady() && ConfigList.Combo.ComboQ)
            {
                var predQ = SpellManager.Q.GetPrediction(target);
                if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.ComboMinToUseQ))
                {
                    SpellManager.Q.Cast(predQ.CastPosition);
                }
            }
            if (SpellManager.W.IsReady() && Player.Instance.IsInRange(target, SpellManager.W.Range) && ConfigList.Combo.ComboW)
            {
                SpellManager.W.Cast(target);
            }
            if (SpellManager.E.IsReady() && Player.Instance.IsInRange(target, SpellManager.E.Range) && ConfigList.Combo.ComboE)
            {
                SpellManager.E.Cast(target);
            }
        }
    }
}