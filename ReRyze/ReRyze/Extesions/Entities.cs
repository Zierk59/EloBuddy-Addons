using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

/*
 * 
 * By MarioGK 
 * Github: https://github.com/mariogk/ItsMeMario
 * 
 * */

namespace ReRyze.Extesions
{
    public static class Entities
    {
        public static Obj_AI_Base GetJungleMinion(float range = 100)
        {
            return
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(range));
        }

        public static int CountEnemyLaneMinions(this Obj_AI_Base target, float range = 100)
        {
            return EntityManager.MinionsAndMonsters.GetLaneMinions().Count(m => m.Distance(target) <= range && m.IsEnemy);
        }

        public static int CountAllyLaneMinions(this Obj_AI_Base target, float range = 100)
        {
            return EntityManager.MinionsAndMonsters.GetLaneMinions().Count(m => m.Distance(target) <= range && m.IsAlly);
        }

        public static int CountJungleMinions(this Obj_AI_Base target, float range = 100)
        {
            return EntityManager.MinionsAndMonsters.GetJungleMonsters().Count(m => m.Distance(target) <= range);
        }

        public static AIHeroClient GetNearestAlly(float range = 700)
        {
            return EntityManager.Heroes.Allies.OrderBy(a => a.Distance(Player.Instance))
                .FirstOrDefault(ally => ally.IsInRange(Player.Instance, range));
        }

        public static AIHeroClient GetNearestLowestAlly(float range = 700)
        {
            return
                EntityManager.Heroes.Allies.OrderBy(a => a.Distance(Player.Instance))
                    .ThenBy(a => a.Health)
                    .FirstOrDefault(ally => ally.IsInRange(Player.Instance, range));
        }

        public static bool GetCollision (Obj_AI_Base target)
        {
            if (SpellManager.Q.GetPrediction(target).HitChance == HitChance.Collision)
                return true;
            return false;
        }

        public static AIHeroClient GetThebestTarget(float range = 200)
        {
            return
                EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenByDescending(TargetSelector.GetPriority)
                    .ThenBy(e => e.FlatArmorMod)
                    .ThenBy(e => e.FlatMagicReduction)
                    .FirstOrDefault(e => e.IsValidTarget(range) && !e.HasUndyingBuff() && !GetCollision(e));
        }

    }
}