﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;
using LightAmumu.Carry;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using Color = System.Drawing.Color;

namespace LightAmumu
{
    internal class Program
    {
        private static List<ModeBase> Modes { get; set; }
        private const int BarWidth = 106;
        private const int LineThickness = 9;
        private static readonly Vector2 BarOffset = new Vector2(0, 0);

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (!Loading.IsLoadingComplete || Player.Instance.ChampionName != "Amumu")
            {
                if (Player.Instance.ChampionName == "Amumu")
                {
                    Chat.Print("LightAmumu - Error with loading!", Color.Red);
                    Chat.Print("LightAmumu - Please reload the addon!", Color.Red);
                }
                else
                {
                    Chat.Print("LightAmumu - You choose wrong champion!", Color.Red);
                }
                return;
            }
            Chat.Print("LightAmumu - Successfully loaded!", Color.ForestGreen);
            DrawingMenu.Initialize();
            Drawing.OnDraw += OnDraw;
            Game.OnTick += OnTick;
            Game.OnUpdate += OnTick;
            Drawing.OnEndScene += OnEndScene;
            Modes = new List<ModeBase>();
            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
                new Combo(),
                new Harras(),
                new LaneClear(),
                new JungleClear()
            });
        }

        private static void OnEndScene(EventArgs args)
        {
            foreach (var unit in EntityManager.Heroes.Enemies.Where(u => u.IsValidTarget() && u.IsHPBarRendered))
            {
                var damage = Damage.GetMaxSpellDamage(unit);
                if (damage <= 0)
                    continue;

                if (MenuList.Misc.HealthbarEnabled)
                {
                    var damagePercentage = ((unit.TotalShieldHealth() - damage) > 0
                        ? (unit.TotalShieldHealth() - damage)
                        : 0) /
                                           (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);
                    var currentHealthPercentage = unit.TotalShieldHealth() /
                                                  (unit.MaxHealth + unit.AllShield + unit.AttackShield +
                                                   unit.MagicShield);
                    var startPoint =
                        new Vector2((int)(unit.HPBarPosition.X + BarOffset.X + damagePercentage * BarWidth),
                            (int)(unit.HPBarPosition.Y + BarOffset.Y) - 5);
                    var endPoint =
                        new Vector2(
                            (int)(unit.HPBarPosition.X + BarOffset.X + currentHealthPercentage * BarWidth) + 1,
                            (int)(unit.HPBarPosition.Y + BarOffset.Y) - 5);
                    Drawing.DrawLine(startPoint, endPoint, LineThickness, Color.LimeGreen);
                }
            }
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead)
                return;

            foreach (var spell in SpellManager.AllSpells) // ty Hellsing Kappa
            {
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        if (!MenuList.Drawing.DrawQ)
                            continue;
                        break;
                    case SpellSlot.W:
                        if (!MenuList.Drawing.DrawW)
                            continue;
                        break;
                    case SpellSlot.E:
                        if (!MenuList.Drawing.DrawE)
                            continue;
                        break;
                    case SpellSlot.R:
                        if (!MenuList.Drawing.DrawR)
                            continue;
                        break;
                }
                Circle.Draw(spell.GetColor(), spell.Range, Player.Instance);
            }
        }

        private static void OnTick(EventArgs args)
        {
            Modes.ForEach(mode =>
            {
                try
                {
                    if (mode.ShouldBeExecuted())
                    {
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}