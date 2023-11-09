using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class HieroglyphTranslator
    {
        private static readonly Dictionary<char, char> Characters = new()
        {
        { 'Ⰰ', 'A' },
        { 'Ⰱ', 'B' },
        { 'Ⰲ', 'C' },
        { 'Ⰳ', 'D' },
        { 'Ⰴ', 'E' },
        { 'Ⱑ', 'F' },
        { 'Ⰵ', 'G' },
        { 'Ⰶ', 'H' },
        { 'Ⰷ', 'I' },
        { 'Ⰸ', 'J' },
        { 'Ⰹ', 'K' },
        { 'Ⰺ', 'L' },
        { 'Ⰻ', 'M' },
        { 'Ⰽ', 'N' },
        { 'Ⰾ', 'O' },
        { 'Ⰿ', 'P' },
        { 'Ⱁ', 'Q' },
        { 'Ⱅ', 'R' },
        { 'Ⱆ', 'S' },
        { 'Ⱈ', 'T' },
        { 'Ⱉ', 'U' },
        { 'Ⱊ', 'V' },
        { 'Ⱋ', 'W' },
        { 'Ⱌ', 'X' },
        { 'Ⱍ', 'Y' },
        { 'Ⱏ', 'Z' },

        };

        public static string TranslateHieroglyphs(string hieroglyphs)
        {
            var translated = new List<char>();
            foreach (var symbol in hieroglyphs)
            {
                if (Characters.TryGetValue(symbol, out var letter))
                {
                    translated.Add(letter);
                }
                else
                {
                    // Als het symbool niet gevonden is, voeg dan een speciaal teken toe of negeer het.
                    translated.Add(' ');
                }
            }
            return new string(translated.ToArray());
        }
    }
}
