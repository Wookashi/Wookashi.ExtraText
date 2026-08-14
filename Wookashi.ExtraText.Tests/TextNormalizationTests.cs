using System.Diagnostics;
using Wookashi.ExtraText.Normalize.Enums;
using Xunit;

namespace Wookashi.ExtraText.Tests
{
    public class TextNormalizationTests
    {
        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")] // Polish
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ae, oe, ue, Ae, Oe, Ue, ss.")]      // German
        public void ReplaceDiacriticalMarks_NoLanguage_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks();
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "ą, ć, ę, ł, ń, ó, ś, ź, ż.")] // Polish
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ä, Ä, ö, Ö, ü, Ü, ß.")]             // German
        public void ReplaceDiacriticalMarks_NoLanguage_Fail(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks();
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("ą", "a")]
        [InlineData("Ą", "A")]
        [InlineData("ć", "c")]
        [InlineData("ę", "e")]
        [InlineData("ł", "l")]
        [InlineData("ń", "n")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ś", "s")]
        [InlineData("ź", "z")]
        [InlineData("ż", "z")]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ä, Ä, ö, Ö, ü, Ü, ß.")]
        public void ReplaceDiacriticalMarks_Polish_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Polish);
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
        public void ReplaceDiacriticalMarks_Polish_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
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
        public void ReplaceDiacriticalMarks_German_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.German);
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
        public void ReplaceDiacriticalMarks_German_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }
        
        [Theory]
        [InlineData("é", "e")]
        [InlineData("è", "e")]
        [InlineData("ê", "e")]
        [InlineData("ë", "e")]
        [InlineData("ç", "c")]
        [InlineData("â", "a")]
        [InlineData("î", "i")]
        [InlineData("ô", "o")]
        [InlineData("ù", "u")]
        [InlineData("Élève très sérieux.", "Eleve tres serieux.")]
        public void ReplaceDiacriticalMarks_French_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.French);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("é", "é", Language.French)]
        [InlineData("ç", "ç", Language.French)]
        [InlineData("Élève très sérieux.", "Élève très sérieux.", Language.French)]
        public void ReplaceDiacriticalMarks_French_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }
        
        [Theory]
        [InlineData("á", "a")]
        [InlineData("é", "e")]
        [InlineData("í", "i")]
        [InlineData("ó", "o")]
        [InlineData("ú", "u")]
        [InlineData("ñ", "n")]
        [InlineData("¿Qué tal, señor?", "¿Que tal, senor?")]
        public void ReplaceDiacriticalMarks_Spanish_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Spanish);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("á", "á", Language.Spanish)]
        [InlineData("ñ", "ñ", Language.Spanish)]
        [InlineData("¿Qué tal, señor?", "¿Qué tal, señor?", Language.Spanish)]
        public void ReplaceDiacriticalMarks_Spanish_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }
        
        [Theory]
        [InlineData("å", "a")]
        [InlineData("ä", "a")]
        [InlineData("ö", "o")]
        [InlineData("Ångström är en enhet.", "Angstrom ar en enhet.")]
        public void ReplaceDiacriticalMarks_Swedish_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Swedish);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("å", "å", Language.Swedish)]
        [InlineData("ä", "ä", Language.Swedish)]
        [InlineData("Ångström är en enhet.", "Ångström är en enhet.", Language.Swedish)]
        public void ReplaceDiacriticalMarks_Swedish_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("á", "a")]
        [InlineData("č", "c")]
        [InlineData("ď", "d")]
        [InlineData("ľ", "l")]
        [InlineData("ň", "n")]
        [InlineData("Študenti študujú.", "Studenti studuju.")]
        public void ReplaceDiacriticalMarks_Slovak_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Slovak);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("č", "č", Language.Slovak)]
        [InlineData("ď", "ď", Language.Slovak)]
        [InlineData("Študenti študujú.", "Študenti študujú.", Language.Slovak)]
        public void ReplaceDiacriticalMarks_Slovak_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("č", "c")]
        [InlineData("ď", "d")]
        [InlineData("ě", "e")]
        [InlineData("ň", "n")]
        [InlineData("ř", "r")]
        [InlineData("šťastný", "stastny")]
        public void ReplaceDiacriticalMarks_Czech_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Czech);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ř", "ř", Language.Czech)]
        [InlineData("šťastný", "šťastný", Language.Czech)]
        public void ReplaceDiacriticalMarks_Czech_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("á", "a")]
        [InlineData("é", "e")]
        [InlineData("í", "i")]
        [InlineData("ó", "o")]
        [InlineData("ö", "o")]
        [InlineData("ő", "o")]
        [InlineData("ú", "u")]
        [InlineData("ü", "u")]
        [InlineData("ű", "u")]
        [InlineData("árvíztűrő tükörfúrógép", "arvizturo tukorfurogep")]
        public void ReplaceDiacriticalMarks_Hungarian_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Hungarian);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("ő", "ő", Language.Hungarian)]
        [InlineData("ű", "ű", Language.Hungarian)]
        [InlineData("árvíztűrő tükörfúrógép", "árvíztűrő tükörfúrógép", Language.Hungarian)]
        public void ReplaceDiacriticalMarks_Hungarian_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Theory]
        [InlineData("č", "c")]
        [InlineData("ć", "c")]
        [InlineData("đ", "d")]
        [InlineData("š", "s")]
        [InlineData("ž", "z")]
        [InlineData("Đorđe je došao.", "Dorde je dosao.")]
        public void ReplaceDiacriticalMarks_Serbian_Pass(string sourceText, string resultText)
        {
            var result = sourceText.ReplaceDiacriticalMarks(Language.Serbian);
            Assert.Equal(resultText, result);
        }

        [Theory]
        [InlineData("č", "č", Language.Serbian)]
        [InlineData("Đorđe je došao.", "Đorđe je došao.", Language.Serbian)]
        public void ReplaceDiacriticalMarks_Serbian_Fail(string sourceText, string resultText, Language language)
        {
            var result = sourceText.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(resultText, result);
        }

        [Fact]
        public void Marks_Replace_Performance()
        {
            var stopWatch = new Stopwatch();
            const string sample = "ąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźż";
            stopWatch.Start();
            sample.ReplaceDiacriticalMarks();
            stopWatch.Stop();
            Assert.True(stopWatch.ElapsedMilliseconds < 1);
        }
    }
}
