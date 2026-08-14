using System.Collections.Generic;
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
            foreach (var dMark in LanguageDiacriticalMark.CanonicalMarks)
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        internal static string ReplaceDiacriticalMarks(string text, Language language)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.ByLanguage[language])
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        internal static string ReplaceDiacriticalMarks(string text, Language[] languages)
        {
            var languageSet = new HashSet<Language>(languages);
            var builder = new StringBuilder(text);
            foreach (var language in languageSet)
            {
                foreach (var dMark in LanguageDiacriticalMark.ByLanguage[language])
                {
                    builder.Replace(dMark.Source, dMark.Target);
                }
            }
            return builder.ToString();
        }
    }
}
