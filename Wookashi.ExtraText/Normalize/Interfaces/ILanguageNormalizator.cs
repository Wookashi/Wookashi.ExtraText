using Wookashi.ExtraText.Normalize.Enums;

namespace Wookashi.ExtraText.Normalize.Interfaces
{
    public interface ILanguageNormalizator
    {
        string RemoveDiactricMarks(string text);
        string RemoveDiactricMarks(string text, Language language);
        string RemoveDiactricMarks(string text, Language[] languages);
    }
}
