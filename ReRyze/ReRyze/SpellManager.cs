using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using System.Collections.Generic;

namespace ReRyze
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        public static readonly int[] ComboMode1 = { 0, 2, 0, 1, 0, 2, 0, 2 };
        public static readonly int[] ComboMode2 = { 0, 2, 2, 0, 1, 0, 2, 0 };
        public static int ComboStep;
        public static int LastCombo = 0;
        public static int LastLaneClear = 0;
        public static int LastAutoHarass = 0;

        public static List<Spell.SpellBase> AllSpells { get; private set; }
        public static Dictionary<SpellSlot, Color> ColorTranslation { get; private set; }

        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 900, SkillShotType.Linear, 250, 1700, 100);
            W = new Spell.Targeted(SpellSlot.W, 600);
            E = new Spell.Targeted(SpellSlot.E, 600);
            R = new Spell.Skillshot(SpellSlot.R, 1500, SkillShotType.Circular);

            AllSpells = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
            ColorTranslation = new Dictionary<SpellSlot, Color>
            {
                { SpellSlot.Q, Color.LimeGreen.ToArgb(150) },
                { SpellSlot.W, Color.CornflowerBlue.ToArgb(150) },
                { SpellSlot.E, Color.YellowGreen.ToArgb(150) },
                { SpellSlot.R, Color.OrangeRed.ToArgb(150) }
            };
        }

        public static void Initialize()
        {
        }

        public static Color ToArgb(this Color color, byte a) // by Hellsing 
        {
            return new ColorBGRA(color.R, color.G, color.B, a);
        }

        public static Color GetColor(this Spell.SpellBase spell) // by Hellsing 
        {
            return ColorTranslation.ContainsKey(spell.Slot) ? ColorTranslation[spell.Slot] : Color.Wheat;
        }
    }
}