﻿using EloBuddy;
using ReKatarina.ReCore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReKatarina.ReCore.Managers
{
    public static class InfoManager
    {
        public static void Show(InventorySlot item, AIHeroClient target)
        {
            if (!MenuHelper.GetCheckBoxValue(ConfigList.Settings.Menu, "Settings.Chat.Status")) return;
            Chat.Print($"<font color='#59c93a'>[ReCORE] </font><font color='#3fbffd'>{item.DisplayName} </font><font color='#f49e00'>has been used at </font><font color='#3fbffd'>{target.ChampionName} ("+ target.Name == Player.Instance.Name ? "me" : target.Name +")</font>");
        }
    }
}
