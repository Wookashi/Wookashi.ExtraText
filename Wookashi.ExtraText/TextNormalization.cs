using System;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Implementation;

namespace Wookashi.ExtraText
{
    public static class TextNormalization
    {
        public static string ReplaceDiacriticalMarks(this string sourceText)
        {
            if (sourceText is null) throw new ArgumentNullException(nameof(sourceText));
            return LanguageNormalizer.ReplaceDiacriticalMarks(sourceText);
        }

        public static string ReplaceDiacriticalMarks(this string sourceText, Language language)
        {
            if (sourceText is null) throw new ArgumentNullException(nameof(sourceText));
            return LanguageNormalizer.ReplaceDiacriticalMarks(sourceText, language);
        }
    }
}
