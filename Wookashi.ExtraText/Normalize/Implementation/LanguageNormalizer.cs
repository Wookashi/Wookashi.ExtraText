using System.Linq;
using System.Text;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Models;

namespace Wookashi.ExtraText.Normalize.Implementation
{
    public class LanguageNormalizer
    {

        public string ReplaceDiacriticalMarks(string text)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.Marks)
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        public string ReplaceDiacriticalMarks(string text, Language language)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.Marks.Where(x => x.Language == language))
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        public string ReplaceDiacriticalMarks(string text, Language[] languages)
        {
            var builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiacriticalMark.Marks.Where(x => languages.Contains(x.Language)))
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }
    }
}
