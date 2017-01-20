using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using System.Collections.Generic;
using SharpDX;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class UltimateTeleport
    {
        private static List<Vector3> GetEnemyInPos()
        {
            List<Vector3> pos = new List<Vector3>();
            foreach (AIHeroClient Hero in EntityManager.Heroes.Enemies.Where(a => !a.IsDead && Player.Instance.Distance(a) <= SpellManager.R.Range))
                pos.Add(Prediction.Position.PredictUnitPosition(Hero, 1500).To3D());
            return pos;
        }

        private static int CountEnemiesUltRange(Vector2 CastPosition)
        {
            int count = 0;
            foreach (Vector3 EnemyPos in GetEnemyInPos())
                if (CastPosition.Distance(EnemyPos) <= 425) 
                    count++;
            return count;
        }
        private static Vector2 GetBestTeleportPos()
        {
            var target = TargetSelector.GetTarget(SpellManager.R.Range, DamageType.Magical, Player.Instance.Position);
            return target.Position.To2D();
        }
        public static void Execute()
        {
            if (!SpellManager.R.IsReady() || !SpellManager.R.IsLearned)
                return;

            Vector2 bestPos = GetBestTeleportPos();
            int allies = Player.Instance.CountAlliesInRange(425) - 1;
            int enemies = CountEnemiesUltRange(bestPos);

            if (allies < ConfigList.UltimateTeleport.MinAllyToTP || enemies < ConfigList.UltimateTeleport.MinEnemyToTP)
                return;

            SpellManager.R.Cast(bestPos.To3D());
        }
    }
}