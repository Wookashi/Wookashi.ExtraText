using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Interfaces;
using Wookashi.ExtraText.Normalize.Models;

namespace Wookashi.ExtraText.Normalize.Implementation
{
    public class LanguageNormalizator : ILanguageNormalizator
    {
        public LanguageNormalizator()
        {
        }

        public string RemoveDiactricMarks(string text)
        {
            StringBuilder builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiactricMark.Marks)
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        public string RemoveDiactricMarks(string text, Language language)
        {
            StringBuilder builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiactricMark.Marks.Where(x => x.Language == language))
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }

        public string RemoveDiactricMarks(string text, Language[] languages)
        {
            StringBuilder builder = new StringBuilder(text);
            foreach (var dMark in LanguageDiactricMark.Marks.Where(x => languages.Contains(x.Language)))
            {
                builder.Replace(dMark.Source, dMark.Target);
            }
            return builder.ToString();
        }
    }
}
