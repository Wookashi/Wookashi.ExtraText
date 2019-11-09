using Wookashi.ExtraText.Normalize.Enums;
using Xunit;

namespace Wookashi.ExtraText.Tests
{
    public class TextNormalizationTests
    {
        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")] // Polish
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ae, oe, ue, Ae, Oe, Ue, ss.")]      // German
        public void RemoveDiactricMarks_NoLanguage_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiactricMarks();
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "ą, ć, ę, ł, ń, ó, ś, ź, ż.")] // Polish
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ä, Ä, ö, Ö, ü, Ü, ß.")]             // German
        public void RemoveDiactricMarks_NoLanguage_Fail(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiactricMarks();
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("ą", "a")]
        [InlineData("ć", "c")]
        [InlineData("ę", "e")]
        [InlineData("ł", "l")]
        [InlineData("ń", "n")]
        [InlineData("ó", "o")]
        [InlineData("ś", "s")]
        [InlineData("ź", "z")]
        [InlineData("ż", "z")]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ä, Ä, ö, Ö, ü, Ü, ß.")]
        public void RemoveDiactricMarks_Polish_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiactricMarks(Language.Polish);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ą", "ą", Language.Polish)]
        [InlineData("ć", "ć", Language.Polish)]
        [InlineData("ę", "ę", Language.Polish)]
        [InlineData("ł", "ł", Language.Polish)]
        [InlineData("ń", "ń", Language.Polish)]
        [InlineData("ó", "ó", Language.Polish)]
        [InlineData("ś", "ś", Language.Polish)]
        [InlineData("ź", "ź", Language.Polish)]
        [InlineData("ż", "ż", Language.Polish)]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "ą, ć, ę, ł, ń, ó, ś, ź, ż.", Language.Polish)]
        public void RemoveDiactricMarks_Polish_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiactricMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("ä", "ae")]
        [InlineData("Ä", "oe")]
        [InlineData("ö", "ue")]
        [InlineData("Ö", "Ae")]
        [InlineData("ü", "Oe")]
        [InlineData("Ü", "Ue")]
        [InlineData("ß", "ss")]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ae, oe, ue, Ae, Oe, Ue, ss.")]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "ą, ć, ę, ł, ń, ó, ś, ź, ż.")]
        public void RemoveDiactricMarks_German_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiactricMarks(Language.German);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ä", "ä", Language.German)]
        [InlineData("Ä", "Ä", Language.German)]
        [InlineData("ö", "ö", Language.German)]
        [InlineData("Ö", "Ö", Language.German)]
        [InlineData("ü", "ü", Language.German)]
        [InlineData("Ü", "Ü", Language.German)]
        [InlineData("ß", "ß", Language.German)]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ä, Ä, ö, Ö, ü, Ü, ß.", Language.German)]
        public void RemoveDiactricMarks_German_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiactricMarks(language);
            Assert.NotEqual(resultText, result);
        }
    }
}