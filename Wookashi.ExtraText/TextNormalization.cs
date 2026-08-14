using System;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Implementation;

namespace Wookashi.ExtraText
{
    public static class TextNormalization
    {
        public static string ReplaceDiacriticalMarks(this string sourceText) =>
            LanguageNormalizer.ReplaceDiacriticalMarks(sourceText);

        public static string ReplaceDiacriticalMarks(this string sourceText, Language language) =>
            LanguageNormalizer.ReplaceDiacriticalMarks(sourceText, language);
    }
}
