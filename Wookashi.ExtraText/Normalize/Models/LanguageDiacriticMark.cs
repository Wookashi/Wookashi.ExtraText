using System.Collections.Generic;
using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Models
{
    public class LanguageDiacriticMark
    {
        public Language Language { get; }
        public string Source { get; }
        public string Target { get; }

        public LanguageDiacriticMark(Language language, string source, string target)
        {
            Language = language;
            Source = source;
            Target = target;
        }

        public static IEnumerable<LanguageDiacriticMark> Marks => new List<LanguageDiacriticMark> {
            // Polish
                new LanguageDiacriticMark(Language.Polish, "ą", "a"),
                new LanguageDiacriticMark(Language.Polish, "ć", "c"),
                new LanguageDiacriticMark(Language.Polish, "ę", "e"),
                new LanguageDiacriticMark(Language.Polish, "ł", "l"),
                new LanguageDiacriticMark(Language.Polish, "ń", "n"),
                new LanguageDiacriticMark(Language.Polish, "ó", "o"),
                new LanguageDiacriticMark(Language.Polish, "ś", "s"),
                new LanguageDiacriticMark(Language.Polish, "ź", "z"),
                new LanguageDiacriticMark(Language.Polish, "ż", "z"),
                new LanguageDiacriticMark(Language.Polish, "Ą", "A"),
                new LanguageDiacriticMark(Language.Polish, "Ć", "C"),
                new LanguageDiacriticMark(Language.Polish, "Ę", "E"),
                new LanguageDiacriticMark(Language.Polish, "Ł", "L"),
                new LanguageDiacriticMark(Language.Polish, "Ń", "N"),
                new LanguageDiacriticMark(Language.Polish, "Ó", "O"),
                new LanguageDiacriticMark(Language.Polish, "Ś", "S"),
                new LanguageDiacriticMark(Language.Polish, "Ż", "Z"),
                new LanguageDiacriticMark(Language.Polish, "Ź", "Z"),
            // German 
                new LanguageDiacriticMark(Language.German, "ä", "ae"),
                new LanguageDiacriticMark(Language.German, "Ä", "oe"),
                new LanguageDiacriticMark(Language.German, "ö", "ue"),
                new LanguageDiacriticMark(Language.German, "Ö", "Ae"),
                new LanguageDiacriticMark(Language.German, "ü", "Oe"),
                new LanguageDiacriticMark(Language.German, "Ü", "Ue"),
                new LanguageDiacriticMark(Language.German, "ß", "ss"),
        };
    }
}

