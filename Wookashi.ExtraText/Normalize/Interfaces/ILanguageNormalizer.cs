using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Interfaces
{
    public interface ILanguageNormalizer
    {
        string ReplaceDiacriticalMarks(string text);
        string ReplaceDiacriticalMarks(string text, Language language);
        string ReplaceDiacriticalMarks(string text, Language[] languages);
    }
}
