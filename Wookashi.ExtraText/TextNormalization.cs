using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Implementation;

namespace Wookashi.ExtraText
{
    public static class TextNormalization
    {
        public static string ReplaceDiactricMarks(this string sourceText)
        {
            var result = string.Empty;
            var normalizator = new LanguageNormalizator();
            result = normalizator.RemoveDiactricMarks(sourceText);
            return result;
        }

        public static string ReplaceDiactricMarks(this string sourceText, Language language)
        {
            var result = string.Empty;
            var normalizator = new LanguageNormalizator();
            result = normalizator.RemoveDiactricMarks(sourceText, language);
            return result;
        }
    }
}
