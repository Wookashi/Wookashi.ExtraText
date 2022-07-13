using System;
using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Interfaces
{
    [Obsolete("Will be deleted in future releases")]
    public interface ILanguageNormalizer
    {
        string ReplaceDiacriticalMarks(string text);
        string ReplaceDiacriticalMarks(string text, Language language);
        string ReplaceDiacriticalMarks(string text, Language[] languages);
    }
}
