using System.Diagnostics;
using Wookashi.ExtraText.Normalize.Enums;
using Xunit;

namespace Wookashi.ExtraText.Tests
{
    public class TextNormalizationTests
    {
        #region Edge Cases

        [Fact]
        public void ReplaceDiacriticalMarks_EmptyString_ReturnsEmptyString()
        {
            var result = "".ReplaceDiacriticalMarks();
            Assert.Equal("", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_WithLanguage_EmptyString_ReturnsEmptyString()
        {
            var result = "".ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_AsciiOnly_ReturnsUnchanged()
        {
            const string input = "Hello World 123!@#$%";
            var result = input.ReplaceDiacriticalMarks();
            Assert.Equal(input, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_WithLanguage_AsciiOnly_ReturnsUnchanged()
        {
            const string input = "Hello World 123!@#$%";
            var result = input.ReplaceDiacriticalMarks(Language.German);
            Assert.Equal(input, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_WhitespaceOnly_ReturnsUnchanged()
        {
            const string input = "   \t\n\r   ";
            var result = input.ReplaceDiacriticalMarks();
            Assert.Equal(input, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_NumbersAndPunctuation_ReturnsUnchanged()
        {
            const string input = "12345.,;:!?()[]{}";
            var result = input.ReplaceDiacriticalMarks();
            Assert.Equal(input, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_SingleCharacter_ReplacesCorrectly()
        {
            Assert.Equal("a", "ą".ReplaceDiacriticalMarks());
        }

        [Fact]
        public void ReplaceDiacriticalMarks_ConsecutiveDiacritics_ReplacesAll()
        {
            Assert.Equal("aaa", "ąąą".ReplaceDiacriticalMarks());
        }

        [Fact]
        public void ReplaceDiacriticalMarks_DiacriticAtStart_ReplacesCorrectly()
        {
            Assert.Equal("abc", "ąbc".ReplaceDiacriticalMarks());
        }

        [Fact]
        public void ReplaceDiacriticalMarks_DiacriticAtEnd_ReplacesCorrectly()
        {
            Assert.Equal("xya", "xyą".ReplaceDiacriticalMarks());
        }

        [Fact]
        public void ReplaceDiacriticalMarks_DiacriticInMiddle_ReplacesCorrectly()
        {
            Assert.Equal("xay", "xąy".ReplaceDiacriticalMarks());
        }

        #endregion

        #region Polish - All Characters

        [Theory]
        [InlineData("ą", "a")]
        [InlineData("Ą", "A")]
        [InlineData("ć", "c")]
        [InlineData("Ć", "C")]
        [InlineData("ę", "e")]
        [InlineData("Ę", "E")]
        [InlineData("ł", "l")]
        [InlineData("Ł", "L")]
        [InlineData("ń", "n")]
        [InlineData("Ń", "N")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ś", "s")]
        [InlineData("Ś", "S")]
        [InlineData("ź", "z")]
        [InlineData("Ź", "Z")]
        [InlineData("ż", "z")]
        [InlineData("Ż", "Z")]
        public void ReplaceDiacriticalMarks_Polish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")]
        [InlineData("Zażółć gęślą jaźń", "Zazolc gesla jazn")]
        [InlineData("ĄĆĘŁŃÓŚŹŻ", "ACELNOSZZ")]
        public void ReplaceDiacriticalMarks_Polish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_Polish_DoesNotAffectGermanMarks()
        {
            const string input = "ä, Ä, ö, Ö, ü, Ü, ß";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal(input, result);
        }

        #endregion

        #region German - All Characters

        [Theory]
        [InlineData("ä", "ae")]
        [InlineData("Ä", "oe")]
        [InlineData("ö", "ue")]
        [InlineData("Ö", "Ae")]
        [InlineData("ü", "Oe")]
        [InlineData("Ü", "Ue")]
        [InlineData("ß", "ss")]
        public void ReplaceDiacriticalMarks_German_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.German);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ae, oe, ue, Ae, Oe, Ue, ss.")]
        public void ReplaceDiacriticalMarks_German_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.German);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_German_DoesNotAffectPolishMarks()
        {
            const string input = "ą, ć, ę, ł, ń, ś, ź, ż";
            var result = input.ReplaceDiacriticalMarks(Language.German);
            Assert.Equal(input, result);
        }

        #endregion

        #region French - All Characters

        [Theory]
        [InlineData("à", "a")]
        [InlineData("À", "A")]
        [InlineData("â", "a")]
        [InlineData("Â", "A")]
        [InlineData("ç", "c")]
        [InlineData("Ç", "C")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("è", "e")]
        [InlineData("È", "E")]
        [InlineData("ê", "e")]
        [InlineData("Ê", "E")]
        [InlineData("ë", "e")]
        [InlineData("Ë", "E")]
        [InlineData("î", "i")]
        [InlineData("Î", "I")]
        [InlineData("ï", "i")]
        [InlineData("Ï", "I")]
        [InlineData("ô", "o")]
        [InlineData("Ô", "O")]
        [InlineData("û", "u")]
        [InlineData("Û", "U")]
        [InlineData("ù", "u")]
        [InlineData("Ù", "U")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        [InlineData("ÿ", "y")]
        [InlineData("Ÿ", "Y")]
        [InlineData("œ", "oe")]
        [InlineData("Œ", "OE")]
        [InlineData("æ", "ae")]
        [InlineData("Æ", "AE")]
        public void ReplaceDiacriticalMarks_French_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.French);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Élève très sérieux.", "Eleve tres serieux.")]
        [InlineData("français", "francais")]
        [InlineData("Ça va bien", "Ca va bien")]
        [InlineData("Cœur", "Coeur")]
        public void ReplaceDiacriticalMarks_French_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.French);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Spanish - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        [InlineData("ñ", "n")]
        [InlineData("Ñ", "N")]
        public void ReplaceDiacriticalMarks_Spanish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Spanish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("¿Qué tal, señor?", "¿Que tal, senor?")]
        [InlineData("España", "Espana")]
        [InlineData("Más información", "Mas informacion")]
        public void ReplaceDiacriticalMarks_Spanish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Spanish);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Swedish - All Characters

        [Theory]
        [InlineData("å", "a")]
        [InlineData("Å", "A")]
        [InlineData("ä", "a")]
        [InlineData("Ä", "A")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        public void ReplaceDiacriticalMarks_Swedish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Swedish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Ångström är en enhet.", "Angstrom ar en enhet.")]
        [InlineData("Älskar", "Alskar")]
        [InlineData("Öresund", "Oresund")]
        public void ReplaceDiacriticalMarks_Swedish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Swedish);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Slovak - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("ä", "a")]
        [InlineData("Ä", "A")]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ď", "d")]
        [InlineData("Ď", "D")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ĺ", "l")]
        [InlineData("Ĺ", "L")]
        [InlineData("ľ", "l")]
        [InlineData("Ľ", "L")]
        [InlineData("ň", "n")]
        [InlineData("Ň", "N")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ô", "o")]
        [InlineData("Ô", "O")]
        [InlineData("ŕ", "r")]
        [InlineData("Ŕ", "R")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ť", "t")]
        [InlineData("Ť", "T")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ý", "y")]
        [InlineData("Ý", "Y")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Slovak_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Slovak);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Študenti študujú.", "Studenti studuju.")]
        [InlineData("Ľúbosť", "Lubost")]
        [InlineData("Mäso", "Maso")]
        public void ReplaceDiacriticalMarks_Slovak_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Slovak);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Czech - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ď", "d")]
        [InlineData("Ď", "D")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("ě", "e")]
        [InlineData("Ě", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ň", "n")]
        [InlineData("Ň", "N")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ř", "r")]
        [InlineData("Ř", "R")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ť", "t")]
        [InlineData("Ť", "T")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ů", "u")]
        [InlineData("Ů", "U")]
        [InlineData("ý", "y")]
        [InlineData("Ý", "Y")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Czech_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Czech);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("šťastný", "stastny")]
        [InlineData("Příliš žluťoučký kůň", "Prilis zlutoucky kun")]
        [InlineData("Řeřicha", "Rericha")]
        public void ReplaceDiacriticalMarks_Czech_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Czech);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Hungarian - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        [InlineData("ő", "o")]
        [InlineData("Ő", "O")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        [InlineData("ű", "u")]
        [InlineData("Ű", "U")]
        public void ReplaceDiacriticalMarks_Hungarian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Hungarian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("árvíztűrő tükörfúrógép", "arvizturo tukorfurogep")]
        [InlineData("Köszönöm szépen", "Koszonom szepen")]
        [InlineData("Őrült Űrhajós", "Orult Urhajos")]
        public void ReplaceDiacriticalMarks_Hungarian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Hungarian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Serbian - All Characters

        [Theory]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ć", "c")]
        [InlineData("Ć", "C")]
        [InlineData("đ", "d")]
        [InlineData("Đ", "D")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Serbian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Serbian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Đorđe je došao.", "Dorde je dosao.")]
        [InlineData("Žena", "Zena")]
        [InlineData("Šljivovica", "Sljivovica")]
        public void ReplaceDiacriticalMarks_Serbian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Serbian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Portuguese - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("à", "a")]
        [InlineData("À", "A")]
        [InlineData("â", "a")]
        [InlineData("Â", "A")]
        [InlineData("ã", "a")]
        [InlineData("Ã", "A")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("ê", "e")]
        [InlineData("Ê", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ô", "o")]
        [InlineData("Ô", "O")]
        [InlineData("õ", "o")]
        [InlineData("Õ", "O")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ç", "c")]
        [InlineData("Ç", "C")]
        public void ReplaceDiacriticalMarks_Portuguese_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Portuguese);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("São Paulo", "Sao Paulo")]
        [InlineData("Coração", "Coracao")]
        [InlineData("Atenção à saúde", "Atencao a saude")]
        [InlineData("Não é possível", "Nao e possivel")]
        public void ReplaceDiacriticalMarks_Portuguese_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Portuguese);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Catalan - All Characters

        [Theory]
        [InlineData("à", "a")]
        [InlineData("À", "A")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("è", "e")]
        [InlineData("È", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ï", "i")]
        [InlineData("Ï", "I")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ò", "o")]
        [InlineData("Ò", "O")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        [InlineData("ç", "c")]
        [InlineData("Ç", "C")]
        public void ReplaceDiacriticalMarks_Catalan_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Catalan);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Barcelona", "Barcelona")]
        [InlineData("Gràcies", "Gracies")]
        [InlineData("Català", "Catala")]
        public void ReplaceDiacriticalMarks_Catalan_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Catalan);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Estonian - All Characters

        [Theory]
        [InlineData("ä", "a")]
        [InlineData("Ä", "A")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        [InlineData("õ", "o")]
        [InlineData("Õ", "O")]
        public void ReplaceDiacriticalMarks_Estonian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Estonian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Tallinn", "Tallinn")]
        [InlineData("Tänan", "Tanan")]
        [InlineData("Tõnu", "Tonu")]
        public void ReplaceDiacriticalMarks_Estonian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Estonian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Latvian - All Characters

        [Theory]
        [InlineData("ā", "a")]
        [InlineData("Ā", "A")]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ē", "e")]
        [InlineData("Ē", "E")]
        [InlineData("ģ", "g")]
        [InlineData("Ģ", "G")]
        [InlineData("ī", "i")]
        [InlineData("Ī", "I")]
        [InlineData("ķ", "k")]
        [InlineData("Ķ", "K")]
        [InlineData("ļ", "l")]
        [InlineData("Ļ", "L")]
        [InlineData("ņ", "n")]
        [InlineData("Ņ", "N")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ū", "u")]
        [InlineData("Ū", "U")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Latvian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Latvian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Rīga", "Riga")]
        [InlineData("Latvija", "Latvija")]
        [InlineData("Paldies", "Paldies")]
        public void ReplaceDiacriticalMarks_Latvian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Latvian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Lithuanian - All Characters

        [Theory]
        [InlineData("ą", "a")]
        [InlineData("Ą", "A")]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ę", "e")]
        [InlineData("Ę", "E")]
        [InlineData("ė", "e")]
        [InlineData("Ė", "E")]
        [InlineData("į", "i")]
        [InlineData("Į", "I")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ų", "u")]
        [InlineData("Ų", "U")]
        [InlineData("ū", "u")]
        [InlineData("Ū", "U")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Lithuanian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Lithuanian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Vilnius", "Vilnius")]
        [InlineData("Lietuva", "Lietuva")]
        [InlineData("Ačiū", "Aciu")]
        public void ReplaceDiacriticalMarks_Lithuanian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Lithuanian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Slovenian - All Characters

        [Theory]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Slovenian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Slovenian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Ljubljana", "Ljubljana")]
        [InlineData("Slovenščina", "Slovenscina")]
        [InlineData("Žalec", "Zalec")]
        public void ReplaceDiacriticalMarks_Slovenian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Slovenian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Croatian - All Characters

        [Theory]
        [InlineData("č", "c")]
        [InlineData("Č", "C")]
        [InlineData("ć", "c")]
        [InlineData("Ć", "C")]
        [InlineData("đ", "d")]
        [InlineData("Đ", "D")]
        [InlineData("š", "s")]
        [InlineData("Š", "S")]
        [InlineData("ž", "z")]
        [InlineData("Ž", "Z")]
        public void ReplaceDiacriticalMarks_Croatian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Croatian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Zagreb", "Zagreb")]
        [InlineData("Hrvatska", "Hrvatska")]
        [InlineData("Čakovec", "Cakovec")]
        public void ReplaceDiacriticalMarks_Croatian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Croatian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Icelandic - All Characters

        [Theory]
        [InlineData("á", "a")]
        [InlineData("Á", "A")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ó", "o")]
        [InlineData("Ó", "O")]
        [InlineData("ú", "u")]
        [InlineData("Ú", "U")]
        [InlineData("ý", "y")]
        [InlineData("Ý", "Y")]
        [InlineData("ð", "d")]
        [InlineData("Ð", "D")]
        [InlineData("þ", "th")]
        [InlineData("Þ", "Th")]
        [InlineData("æ", "ae")]
        [InlineData("Æ", "AE")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        public void ReplaceDiacriticalMarks_Icelandic_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Icelandic);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Reykjavík", "Reykjavik")]
        [InlineData("Þórður", "Thordur")]
        [InlineData("Eyjafjallajökull", "Eyjafjallajokull")]
        public void ReplaceDiacriticalMarks_Icelandic_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Icelandic);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Finnish - All Characters

        [Theory]
        [InlineData("ä", "a")]
        [InlineData("Ä", "A")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        public void ReplaceDiacriticalMarks_Finnish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Finnish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hyvää päivää", "Hyvaa paivaa")]
        [InlineData("Jyväskylä", "Jyvaskyla")]
        [InlineData("Öljy", "Oljy")]
        public void ReplaceDiacriticalMarks_Finnish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Finnish);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Norwegian - All Characters

        [Theory]
        [InlineData("æ", "ae")]
        [InlineData("Æ", "AE")]
        [InlineData("ø", "o")]
        [InlineData("Ø", "O")]
        [InlineData("å", "a")]
        [InlineData("Å", "A")]
        public void ReplaceDiacriticalMarks_Norwegian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Norwegian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Trøndelag", "Trondelag")]
        [InlineData("Værøy", "Vaeroy")]
        [InlineData("Ålesund", "Alesund")]
        public void ReplaceDiacriticalMarks_Norwegian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Norwegian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Danish - All Characters

        [Theory]
        [InlineData("æ", "ae")]
        [InlineData("Æ", "AE")]
        [InlineData("ø", "o")]
        [InlineData("Ø", "O")]
        [InlineData("å", "a")]
        [InlineData("Å", "A")]
        public void ReplaceDiacriticalMarks_Danish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Danish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("København", "Kobenhavn")]
        [InlineData("Rødgrød med fløde", "Rodgrod med flode")]
        [InlineData("Ålborg", "Alborg")]
        public void ReplaceDiacriticalMarks_Danish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Danish);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Turkish - All Characters

        [Theory]
        [InlineData("ç", "c")]
        [InlineData("Ç", "C")]
        [InlineData("ğ", "g")]
        [InlineData("Ğ", "G")]
        [InlineData("ı", "i")]
        [InlineData("İ", "I")]
        [InlineData("ö", "o")]
        [InlineData("Ö", "O")]
        [InlineData("ş", "s")]
        [InlineData("Ş", "S")]
        [InlineData("ü", "u")]
        [InlineData("Ü", "U")]
        public void ReplaceDiacriticalMarks_Turkish_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Turkish);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("İstanbul", "Istanbul")]
        [InlineData("Türkiye", "Turkiye")]
        [InlineData("Teşekkürler", "Tesekkurler")]
        public void ReplaceDiacriticalMarks_Turkish_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Turkish);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Romanian - All Characters

        [Theory]
        [InlineData("ă", "a")]
        [InlineData("Ă", "A")]
        [InlineData("â", "a")]
        [InlineData("Â", "A")]
        [InlineData("î", "i")]
        [InlineData("Î", "I")]
        [InlineData("ș", "s")]
        [InlineData("Ș", "S")]
        [InlineData("ț", "t")]
        [InlineData("Ț", "T")]
        public void ReplaceDiacriticalMarks_Romanian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Romanian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("București", "Bucuresti")]
        [InlineData("România", "Romania")]
        [InlineData("Mulțumesc", "Multumesc")]
        public void ReplaceDiacriticalMarks_Romanian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Romanian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Italian - All Characters

        [Theory]
        [InlineData("à", "a")]
        [InlineData("À", "A")]
        [InlineData("è", "e")]
        [InlineData("È", "E")]
        [InlineData("é", "e")]
        [InlineData("É", "E")]
        [InlineData("ì", "i")]
        [InlineData("Ì", "I")]
        [InlineData("ò", "o")]
        [InlineData("Ò", "O")]
        [InlineData("ù", "u")]
        [InlineData("Ù", "U")]
        public void ReplaceDiacriticalMarks_Italian_IndividualCharacters(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Italian);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Città", "Citta")]
        [InlineData("Perché no?", "Perche no?")]
        [InlineData("È vero", "E vero")]
        public void ReplaceDiacriticalMarks_Italian_Sentences(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks(Language.Italian);
            Assert.Equal(expected, result);
        }

        #endregion

        #region No Language Specified - All Languages Combined

        [Theory]
        [InlineData("ą, ć, ę, ł, ń, ó, ś, ź, ż.", "a, c, e, l, n, o, s, z, z.")]
        [InlineData("ä, Ä, ö, Ö, ü, Ü, ß.", "ae, oe, ue, Ae, Oe, Ue, ss.")]
        public void ReplaceDiacriticalMarks_NoLanguage_ReplacesAllMarks(string source, string expected)
        {
            var result = source.ReplaceDiacriticalMarks();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_NoLanguage_MixedLanguages_ReplacesAll()
        {
            const string input = "żółć über café";
            var result = input.ReplaceDiacriticalMarks();
            Assert.DoesNotContain("ż", result);
            Assert.DoesNotContain("ó", result);
            Assert.DoesNotContain("ł", result);
            Assert.DoesNotContain("ć", result);
            Assert.DoesNotContain("ü", result);
            Assert.DoesNotContain("é", result);
        }

        #endregion

        #region Language Isolation Tests

        [Fact]
        public void ReplaceDiacriticalMarks_PolishLanguage_OnlyReplacesPolishMarks()
        {
            const string input = "ą ü é";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("a ü é", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_GermanLanguage_OnlyReplacesGermanMarks()
        {
            const string input = "ą ü é";
            var result = input.ReplaceDiacriticalMarks(Language.German);
            Assert.Contains("ą", result);
            Assert.DoesNotContain("ü", result);
            Assert.Contains("é", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_FrenchLanguage_OnlyReplacesFrenchMarks()
        {
            const string input = "ą ü é";
            var result = input.ReplaceDiacriticalMarks(Language.French);
            Assert.Equal("ą u e", result);
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void ReplaceDiacriticalMarks_Performance_ShortString()
        {
            var stopWatch = new Stopwatch();
            const string sample = "ąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźż";
            stopWatch.Start();
            sample.ReplaceDiacriticalMarks();
            stopWatch.Stop();
            Assert.True(stopWatch.ElapsedMilliseconds < 1);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_Performance_LongString()
        {
            var stopWatch = new Stopwatch();
            var sample = new string('ą', 10000);
            stopWatch.Start();
            var result = sample.ReplaceDiacriticalMarks();
            stopWatch.Stop();
            Assert.Equal(10000, result.Length);
            Assert.True(stopWatch.ElapsedMilliseconds < 100);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_Performance_MultipleIterations()
        {
            var stopWatch = new Stopwatch();
            const string sample = "Zażółć gęślą jaźń";
            stopWatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                sample.ReplaceDiacriticalMarks();
            }
            stopWatch.Stop();
            Assert.True(stopWatch.ElapsedMilliseconds < 1000);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_WithLanguage_Performance()
        {
            var stopWatch = new Stopwatch();
            const string sample = "ąćęłńóśźżąćęłńóśźżąćęłńóśźżąćęłńóśźż";
            stopWatch.Start();
            sample.ReplaceDiacriticalMarks(Language.Polish);
            stopWatch.Stop();
            Assert.True(stopWatch.ElapsedMilliseconds < 1);
        }

        #endregion

        #region Special Scenarios

        [Fact]
        public void ReplaceDiacriticalMarks_MixedCaseText_PreservesNonDiacriticCase()
        {
            const string input = "HeLLo WoRLD ąĄćĆ";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("HeLLo WoRLD aAcC", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_TextWithNumbers_PreservesNumbers()
        {
            const string input = "Test123ąćę456";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("Test123ace456", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_TextWithSpecialCharacters_PreservesSpecialChars()
        {
            const string input = "Hello!@#$%^&*()ąćę";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("Hello!@#$%^&*()ace", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_MultiLineText_HandlesNewlines()
        {
            const string input = "Line1 ą\nLine2 ć\rLine3 ę";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("Line1 a\nLine2 c\rLine3 e", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_TabsAndSpaces_PreservesWhitespace()
        {
            const string input = "Tab\tą\tSpace ć ę";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("Tab\ta\tSpace c e", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_RepeatedSameCharacter_ReplacesAll()
        {
            const string input = "ąąąąą";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("aaaaa", result);
        }

        [Fact]
        public void ReplaceDiacriticalMarks_AlternatingDiacritics_ReplacesCorrectly()
        {
            const string input = "ąaąaą";
            var result = input.ReplaceDiacriticalMarks(Language.Polish);
            Assert.Equal("aaaaa", result);
        }

        #endregion

        #region Negative Tests - Verify Marks Are Not Equal After Replacement

        [Theory]
        [InlineData("ą", "ą", Language.Polish)]
        [InlineData("ć", "ć", Language.Polish)]
        [InlineData("ę", "ę", Language.Polish)]
        public void ReplaceDiacriticalMarks_Polish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ä", "ä", Language.German)]
        [InlineData("ö", "ö", Language.German)]
        [InlineData("ü", "ü", Language.German)]
        [InlineData("ß", "ß", Language.German)]
        public void ReplaceDiacriticalMarks_German_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("é", "é", Language.French)]
        [InlineData("ç", "ç", Language.French)]
        [InlineData("à", "à", Language.French)]
        public void ReplaceDiacriticalMarks_French_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ñ", "ñ", Language.Spanish)]
        [InlineData("á", "á", Language.Spanish)]
        public void ReplaceDiacriticalMarks_Spanish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("å", "å", Language.Swedish)]
        [InlineData("ä", "ä", Language.Swedish)]
        [InlineData("ö", "ö", Language.Swedish)]
        public void ReplaceDiacriticalMarks_Swedish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("č", "č", Language.Slovak)]
        [InlineData("ľ", "ľ", Language.Slovak)]
        [InlineData("ť", "ť", Language.Slovak)]
        public void ReplaceDiacriticalMarks_Slovak_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ř", "ř", Language.Czech)]
        [InlineData("ě", "ě", Language.Czech)]
        [InlineData("ů", "ů", Language.Czech)]
        public void ReplaceDiacriticalMarks_Czech_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ő", "ő", Language.Hungarian)]
        [InlineData("ű", "ű", Language.Hungarian)]
        public void ReplaceDiacriticalMarks_Hungarian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("đ", "đ", Language.Serbian)]
        [InlineData("ć", "ć", Language.Serbian)]
        public void ReplaceDiacriticalMarks_Serbian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ã", "ã", Language.Portuguese)]
        [InlineData("õ", "õ", Language.Portuguese)]
        [InlineData("ç", "ç", Language.Portuguese)]
        public void ReplaceDiacriticalMarks_Portuguese_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("à", "à", Language.Italian)]
        [InlineData("è", "è", Language.Italian)]
        [InlineData("ì", "ì", Language.Italian)]
        public void ReplaceDiacriticalMarks_Italian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ă", "ă", Language.Romanian)]
        [InlineData("ș", "ș", Language.Romanian)]
        [InlineData("ț", "ț", Language.Romanian)]
        public void ReplaceDiacriticalMarks_Romanian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ğ", "ğ", Language.Turkish)]
        [InlineData("ş", "ş", Language.Turkish)]
        [InlineData("ı", "ı", Language.Turkish)]
        public void ReplaceDiacriticalMarks_Turkish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("æ", "æ", Language.Danish)]
        [InlineData("ø", "ø", Language.Danish)]
        [InlineData("å", "å", Language.Danish)]
        public void ReplaceDiacriticalMarks_Danish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("æ", "æ", Language.Norwegian)]
        [InlineData("ø", "ø", Language.Norwegian)]
        [InlineData("å", "å", Language.Norwegian)]
        public void ReplaceDiacriticalMarks_Norwegian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ä", "ä", Language.Finnish)]
        [InlineData("ö", "ö", Language.Finnish)]
        public void ReplaceDiacriticalMarks_Finnish_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ð", "ð", Language.Icelandic)]
        [InlineData("þ", "þ", Language.Icelandic)]
        [InlineData("æ", "æ", Language.Icelandic)]
        public void ReplaceDiacriticalMarks_Icelandic_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("č", "č", Language.Croatian)]
        [InlineData("đ", "đ", Language.Croatian)]
        [InlineData("ž", "ž", Language.Croatian)]
        public void ReplaceDiacriticalMarks_Croatian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("č", "č", Language.Slovenian)]
        [InlineData("š", "š", Language.Slovenian)]
        [InlineData("ž", "ž", Language.Slovenian)]
        public void ReplaceDiacriticalMarks_Slovenian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ą", "ą", Language.Lithuanian)]
        [InlineData("ė", "ė", Language.Lithuanian)]
        [InlineData("ū", "ū", Language.Lithuanian)]
        public void ReplaceDiacriticalMarks_Lithuanian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ā", "ā", Language.Latvian)]
        [InlineData("ģ", "ģ", Language.Latvian)]
        [InlineData("ķ", "ķ", Language.Latvian)]
        public void ReplaceDiacriticalMarks_Latvian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("ä", "ä", Language.Estonian)]
        [InlineData("õ", "õ", Language.Estonian)]
        [InlineData("ü", "ü", Language.Estonian)]
        public void ReplaceDiacriticalMarks_Estonian_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        [Theory]
        [InlineData("à", "à", Language.Catalan)]
        [InlineData("è", "è", Language.Catalan)]
        [InlineData("ç", "ç", Language.Catalan)]
        public void ReplaceDiacriticalMarks_Catalan_ResultDiffersFromSource(string source, string notExpected, Language language)
        {
            var result = source.ReplaceDiacriticalMarks(language);
            Assert.NotEqual(notExpected, result);
        }

        #endregion

        #region All Languages Enum Values Tested

        [Theory]
        [InlineData(Language.Polish)]
        [InlineData(Language.German)]
        [InlineData(Language.French)]
        [InlineData(Language.Spanish)]
        [InlineData(Language.Swedish)]
        [InlineData(Language.Slovak)]
        [InlineData(Language.Czech)]
        [InlineData(Language.Hungarian)]
        [InlineData(Language.Serbian)]
        [InlineData(Language.Portuguese)]
        [InlineData(Language.Italian)]
        [InlineData(Language.Romanian)]
        [InlineData(Language.Turkish)]
        [InlineData(Language.Danish)]
        [InlineData(Language.Norwegian)]
        [InlineData(Language.Finnish)]
        [InlineData(Language.Icelandic)]
        [InlineData(Language.Croatian)]
        [InlineData(Language.Slovenian)]
        [InlineData(Language.Lithuanian)]
        [InlineData(Language.Latvian)]
        [InlineData(Language.Estonian)]
        [InlineData(Language.Catalan)]
        public void ReplaceDiacriticalMarks_AllLanguages_DoNotThrow(Language language)
        {
            const string input = "Test string with no diacritics";
            var exception = Record.Exception(() => input.ReplaceDiacriticalMarks(language));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(Language.Polish)]
        [InlineData(Language.German)]
        [InlineData(Language.French)]
        [InlineData(Language.Spanish)]
        [InlineData(Language.Swedish)]
        [InlineData(Language.Slovak)]
        [InlineData(Language.Czech)]
        [InlineData(Language.Hungarian)]
        [InlineData(Language.Serbian)]
        [InlineData(Language.Portuguese)]
        [InlineData(Language.Italian)]
        [InlineData(Language.Romanian)]
        [InlineData(Language.Turkish)]
        [InlineData(Language.Danish)]
        [InlineData(Language.Norwegian)]
        [InlineData(Language.Finnish)]
        [InlineData(Language.Icelandic)]
        [InlineData(Language.Croatian)]
        [InlineData(Language.Slovenian)]
        [InlineData(Language.Lithuanian)]
        [InlineData(Language.Latvian)]
        [InlineData(Language.Estonian)]
        [InlineData(Language.Catalan)]
        public void ReplaceDiacriticalMarks_AllLanguages_EmptyStringDoesNotThrow(Language language)
        {
            var exception = Record.Exception(() => "".ReplaceDiacriticalMarks(language));
            Assert.Null(exception);
        }

        #endregion
    }
}
