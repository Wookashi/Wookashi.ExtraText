using System.Collections.Generic;
using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Models
{
    internal sealed class LanguageDiacriticalMark
    {
        public Language Language { get; }
        public string Source { get; }
        public string Target { get; }

        private LanguageDiacriticalMark(Language language, string source, string target)
        {
            Language = language;
            Source = source;
            Target = target;
        }

        internal static IEnumerable<LanguageDiacriticalMark> Marks => new List<LanguageDiacriticalMark>
        {
            // Polish
            new LanguageDiacriticalMark(Language.Polish, "ą", "a"),
            new LanguageDiacriticalMark(Language.Polish, "ć", "c"),
            new LanguageDiacriticalMark(Language.Polish, "ę", "e"),
            new LanguageDiacriticalMark(Language.Polish, "ł", "l"),
            new LanguageDiacriticalMark(Language.Polish, "ń", "n"),
            new LanguageDiacriticalMark(Language.Polish, "ó", "o"),
            new LanguageDiacriticalMark(Language.Polish, "ś", "s"),
            new LanguageDiacriticalMark(Language.Polish, "ź", "z"),
            new LanguageDiacriticalMark(Language.Polish, "ż", "z"),
            new LanguageDiacriticalMark(Language.Polish, "Ą", "A"),
            new LanguageDiacriticalMark(Language.Polish, "Ć", "C"),
            new LanguageDiacriticalMark(Language.Polish, "Ę", "E"),
            new LanguageDiacriticalMark(Language.Polish, "Ł", "L"),
            new LanguageDiacriticalMark(Language.Polish, "Ń", "N"),
            new LanguageDiacriticalMark(Language.Polish, "Ó", "O"),
            new LanguageDiacriticalMark(Language.Polish, "Ś", "S"),
            new LanguageDiacriticalMark(Language.Polish, "Ż", "Z"),
            new LanguageDiacriticalMark(Language.Polish, "Ź", "Z"),
            // German 
            new LanguageDiacriticalMark(Language.German, "ä", "ae"),
            new LanguageDiacriticalMark(Language.German, "Ä", "oe"),
            new LanguageDiacriticalMark(Language.German, "ö", "ue"),
            new LanguageDiacriticalMark(Language.German, "Ö", "Ae"),
            new LanguageDiacriticalMark(Language.German, "ü", "Oe"),
            new LanguageDiacriticalMark(Language.German, "Ü", "Ue"),
            new LanguageDiacriticalMark(Language.German, "ß", "ss"),
            // French 
            new LanguageDiacriticalMark(Language.French, "à", "a"),
            new LanguageDiacriticalMark(Language.French, "À", "A"),
            new LanguageDiacriticalMark(Language.French, "â", "a"),
            new LanguageDiacriticalMark(Language.French, "Â", "A"),
            new LanguageDiacriticalMark(Language.French, "ç", "c"),
            new LanguageDiacriticalMark(Language.French, "Ç", "C"),
            new LanguageDiacriticalMark(Language.French, "é", "e"),
            new LanguageDiacriticalMark(Language.French, "É", "E"),
            new LanguageDiacriticalMark(Language.French, "è", "e"),
            new LanguageDiacriticalMark(Language.French, "È", "E"),
            new LanguageDiacriticalMark(Language.French, "ê", "e"),
            new LanguageDiacriticalMark(Language.French, "Ê", "E"),
            new LanguageDiacriticalMark(Language.French, "ë", "e"),
            new LanguageDiacriticalMark(Language.French, "Ë", "E"),
            new LanguageDiacriticalMark(Language.French, "î", "i"),
            new LanguageDiacriticalMark(Language.French, "Î", "I"),
            new LanguageDiacriticalMark(Language.French, "ï", "i"),
            new LanguageDiacriticalMark(Language.French, "Ï", "I"),
            new LanguageDiacriticalMark(Language.French, "ô", "o"),
            new LanguageDiacriticalMark(Language.French, "Ô", "O"),
            new LanguageDiacriticalMark(Language.French, "û", "u"),
            new LanguageDiacriticalMark(Language.French, "Û", "U"),
            new LanguageDiacriticalMark(Language.French, "ù", "u"),
            new LanguageDiacriticalMark(Language.French, "Ù", "U"),
            new LanguageDiacriticalMark(Language.French, "ü", "u"),
            new LanguageDiacriticalMark(Language.French, "Ü", "U"),
            new LanguageDiacriticalMark(Language.French, "ÿ", "y"),
            new LanguageDiacriticalMark(Language.French, "Ÿ", "Y"),
            new LanguageDiacriticalMark(Language.French, "œ", "oe"),
            new LanguageDiacriticalMark(Language.French, "Œ", "OE"),
            new LanguageDiacriticalMark(Language.French, "æ", "ae"),
            new LanguageDiacriticalMark(Language.French, "Æ", "AE"),
            // Czech 
            new LanguageDiacriticalMark(Language.Czech, "á", "a"),
            new LanguageDiacriticalMark(Language.Czech, "Á", "A"),
            new LanguageDiacriticalMark(Language.Czech, "č", "c"),
            new LanguageDiacriticalMark(Language.Czech, "Č", "C"),
            new LanguageDiacriticalMark(Language.Czech, "ď", "d"),
            new LanguageDiacriticalMark(Language.Czech, "Ď", "D"),
            new LanguageDiacriticalMark(Language.Czech, "é", "e"),
            new LanguageDiacriticalMark(Language.Czech, "É", "E"),
            new LanguageDiacriticalMark(Language.Czech, "ě", "e"),
            new LanguageDiacriticalMark(Language.Czech, "Ě", "E"),
            new LanguageDiacriticalMark(Language.Czech, "í", "i"),
            new LanguageDiacriticalMark(Language.Czech, "Í", "I"),
            new LanguageDiacriticalMark(Language.Czech, "ň", "n"),
            new LanguageDiacriticalMark(Language.Czech, "Ň", "N"),
            new LanguageDiacriticalMark(Language.Czech, "ó", "o"),
            new LanguageDiacriticalMark(Language.Czech, "Ó", "O"),
            new LanguageDiacriticalMark(Language.Czech, "ř", "r"),
            new LanguageDiacriticalMark(Language.Czech, "Ř", "R"),
            new LanguageDiacriticalMark(Language.Czech, "š", "s"),
            new LanguageDiacriticalMark(Language.Czech, "Š", "S"),
            new LanguageDiacriticalMark(Language.Czech, "ť", "t"),
            new LanguageDiacriticalMark(Language.Czech, "Ť", "T"),
            new LanguageDiacriticalMark(Language.Czech, "ú", "u"),
            new LanguageDiacriticalMark(Language.Czech, "Ú", "U"),
            new LanguageDiacriticalMark(Language.Czech, "ů", "u"),
            new LanguageDiacriticalMark(Language.Czech, "Ů", "U"),
            new LanguageDiacriticalMark(Language.Czech, "ý", "y"),
            new LanguageDiacriticalMark(Language.Czech, "Ý", "Y"),
            new LanguageDiacriticalMark(Language.Czech, "ž", "z"),
            new LanguageDiacriticalMark(Language.Czech, "Ž", "Z"),
        };
    }
}