using System.Linq;
using System.Text;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Models;

namespace Wookashi.ExtraText.Normalize.Implementation
{
    internal static class LanguageNormalizer
    {
        internal static string ReplaceDiacriticalMarks(string text)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.Marks)
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        internal static string ReplaceDiacriticalMarks(string text, Language language)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.Marks.Where(x => x.Language == language))
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }
    }
}
