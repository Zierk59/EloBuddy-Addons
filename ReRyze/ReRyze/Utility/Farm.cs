using EloBuddy;
using EloBuddy.SDK;
using ReRyze.ConfigList;
using System;
using System.Linq;

namespace ReRyze.Utility
{
    public static class Farm
    {
        public static void Execute()
        {
            if (Environment.TickCount - SpellManager.LastLaneClear < Game.Ping * 2)
                return;

            int delay = 0;
            if (ConfigList.Farm.FarmQ && SpellManager.Q.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearQ_Mana && (Player.Instance.HasBuff("RyzeQIconFullCharge") || Player.Instance.HasBuff("RyzeQIconNoCharge")))
            {
                var target = new Obj_AI_Base();
                target = Extesions.Entities.GetJungleMinion(SpellManager.Q.Range);
                switch (target != null ? true : false)
                {
                    case true: break; // jungle clear
                    case false: // lane clear
                        {
                            target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range)).FirstOrDefault();
                            break;
                        }
                }
                if (target != null)
                    if (target.TotalShieldHealth() <= Damage.GetQDamage(target) || target.TotalShieldHealth() / Damage.GetQDamage(target) > 2)
                    {
                        var predQ = SpellManager.Q.GetPrediction(target);
                        if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.LaneClearMinToUseQ))
                            Core.DelayAction(() => SpellManager.Q.Cast(predQ.CastPosition), delay);
                    }
            }
            if (ConfigList.Farm.FarmE && SpellManager.E.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearE_Mana && !Player.Instance.HasBuff("RyzeQIconFullCharge"))
            {
                var target = new Obj_AI_Base();
                target = Extesions.Entities.GetJungleMinion(SpellManager.E.Range);
                switch (target != null ? true : false)
                {
                    case true: // jungle clear
                        {
                            var monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.E.Range));
                            if (!ConfigList.Farm.FarmEIgnore && monsters.Count() < ConfigList.Farm.FarmECount)
                                return;
                            break;
                        }
                    case false: // lane clear
                        {
                            var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.E.Range));
                            if (minions.Count() < ConfigList.Farm.FarmECount)
                                return;

                            target = minions.FirstOrDefault();
                            break;
                        }
                }
                if (target != null)
                    SpellManager.E.Cast(target);
            }
            SpellManager.LastLaneClear = Environment.TickCount;
        }
    }
}
