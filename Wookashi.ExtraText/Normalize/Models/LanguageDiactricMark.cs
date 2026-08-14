using System;
using System.Collections.Generic;
using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Models
{
    public class LanguageDiactricMark
    {
        public Language Language { get; private set; }
        public string Source { get; private set; }
        public string Target { get; private set; }

        public LanguageDiactricMark(Language language, string source, string target)
        {
            Language = language;
            Source = source;
            Target = target;
        }

        public static List<LanguageDiactricMark> Marks => new List<LanguageDiactricMark> {
            // Polish
                new LanguageDiactricMark(Language.Polish, "ą", "a"),
                new LanguageDiactricMark(Language.Polish, "ć", "c"),
                new LanguageDiactricMark(Language.Polish, "ę", "e"),
                new LanguageDiactricMark(Language.Polish, "ł", "l"),
                new LanguageDiactricMark(Language.Polish, "ń", "n"),
                new LanguageDiactricMark(Language.Polish, "ó", "o"),
                new LanguageDiactricMark(Language.Polish, "ś", "s"),
                new LanguageDiactricMark(Language.Polish, "ź", "z"),
                new LanguageDiactricMark(Language.Polish, "ż", "z"),
            // German 
                new LanguageDiactricMark(Language.German, "ä", "ae"),
                new LanguageDiactricMark(Language.German, "Ä", "oe"),
                new LanguageDiactricMark(Language.German, "ö", "ue"),
                new LanguageDiactricMark(Language.German, "Ö", "Ae"),
                new LanguageDiactricMark(Language.German, "ü", "Oe"),
                new LanguageDiactricMark(Language.German, "Ü", "Ue"),
                new LanguageDiactricMark(Language.German, "ß", "ss"),
        };
    }
}

