using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Implementation;

namespace Wookashi.ExtraText
{
    public static class TextNormalization
    {
        public static string ReplaceDiacriticalMarks(this string sourceText)
        {
            var normalizer = new LanguageNormalizer();
            var result = normalizer.ReplaceDiacriticalMarks(sourceText);
            return result;
        }

        public static string ReplaceDiacriticalMarks(this string sourceText, Language language)
        {
            var normalizer = new LanguageNormalizer();
            var result = normalizer.ReplaceDiacriticalMarks(sourceText, language);
            return result;
        }
    }
}
