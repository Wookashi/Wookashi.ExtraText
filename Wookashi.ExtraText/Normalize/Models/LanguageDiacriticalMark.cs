using System.Collections.Generic;
using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Models
{
    public class LanguageDiacriticalMark
    {
        public Language Language { get; }
        public string Source { get; }
        public string Target { get; }

        public LanguageDiacriticalMark(Language language, string source, string target)
        {
            Language = language;
            Source = source;
            Target = target;
        }

        public static IEnumerable<LanguageDiacriticalMark> Marks => new List<LanguageDiacriticalMark> {
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
        };
    }
}

