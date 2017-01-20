using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using ReRyze.Utility;
using System;

namespace ReRyze
{
    class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("ReRyze has been disabled. Wait for rework, soonTM.");
            return;
            /*
            if (Player.Instance.ChampionName != "Ryze")
            {
                return;
            }

            Config.Initialize();
            Drawing.OnDraw += OnDraw;
            Game.OnTick += OnTick;
            Game.OnUpdate += OnTick;
            Drawing.OnEndScene += OnEndScene;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            ReKatarina.ReCore.Loader.Initialize();

            Chat.Print("ReRyze has been loaded. GL HF;");*/
        }

        private static void OnEndScene(EventArgs args)
        {
            if (Player.Instance.IsDead || !ConfigList.Drawing.DrawDI)
                return;

            Indicator.Execute();
        }

        private static void OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead || Player.Instance.IsRecalling()) 
                return;

            Orbwalker.ForcedTarget = null;
            PermaActive.Execute();
            var flags = Orbwalker.ActiveModesFlags;
            if (flags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
                Orbwalker.DisableAttacking = false;
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Harass.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                LastHit.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Farm.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                Farm.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.Flee))
            {
                Flee.Execute();
            }
            if (ConfigList.UltimateTeleport.TeleportKey)
            {
                UltimateTeleport.Execute();
            }
        }

        public static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Player.Instance.IsDead || !sender.IsEnemy || !ConfigList.Misc.GapCloser) return;
            if (!SpellManager.W.IsReady() || !sender.IsValidTarget(SpellManager.W.Range)) return;

            SpellManager.W.Cast(sender);
            return;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead)
                return;

            foreach (var spell in SpellManager.AllSpells)
            {
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        if (!ConfigList.Drawing.DrawQ)
                            continue;
                        break;
                    case SpellSlot.W:
                        if (!ConfigList.Drawing.DrawW)
                            continue;
                        continue;
                    case SpellSlot.E:
                        if (!ConfigList.Drawing.DrawE)
                            continue;
                        break;
                    case SpellSlot.R:
                        if (!ConfigList.Drawing.DrawR)
                            continue;
                        break;
                }
                Circle.Draw(spell.GetColor(), spell.Range, Player.Instance);
            }
        }
    }
}