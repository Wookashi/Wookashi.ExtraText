using System;
using Wookashi.ExtraText.Normalize.Enums;
using Wookashi.ExtraText.Normalize.Implementation;

namespace Wookashi.ExtraText
{
    /// <summary>
    /// Extension methods for removing diacritical marks (accents) from text.
    /// </summary>
    public static class TextNormalization
    {
        /// <summary>
        /// Replaces diacritical marks from all supported languages with their closest ASCII equivalent.
        /// For characters transliterated differently depending on language (e.g. <c>ä</c>, <c>ö</c>,
        /// <c>ü</c>), the plain letter is used rather than any single language's convention (such as
        /// German's <c>ae</c>/<c>oe</c>/<c>ue</c> digraphs), so the result is deterministic regardless of
        /// the text's actual source language. Use <see cref="ReplaceDiacriticalMarks(string, Language)"/>
        /// to get a specific language's convention instead.
        /// </summary>
        /// <param name="sourceText">The text to normalize.</param>
        /// <returns>The normalized text.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="sourceText"/> is <see langword="null"/>.</exception>
        public static string ReplaceDiacriticalMarks(this string sourceText)
        {
            if (sourceText is null) throw new ArgumentNullException(nameof(sourceText));
            return LanguageNormalizer.ReplaceDiacriticalMarks(sourceText);
        }

        /// <summary>
        /// Replaces diacritical marks belonging to the specified <paramref name="language"/> only,
        /// leaving marks from other languages untouched.
        /// </summary>
        /// <param name="sourceText">The text to normalize.</param>
        /// <param name="language">The language whose diacritical marks should be replaced.</param>
        /// <returns>The normalized text.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="sourceText"/> is <see langword="null"/>.</exception>
        public static string ReplaceDiacriticalMarks(this string sourceText, Language language)
        {
            if (sourceText is null) throw new ArgumentNullException(nameof(sourceText));
            return LanguageNormalizer.ReplaceDiacriticalMarks(sourceText, language);
        }

        /// <summary>
        /// Replaces diacritical marks belonging to any of the specified <paramref name="languages"/>,
        /// leaving marks from other languages untouched.
        /// </summary>
        /// <param name="sourceText">The text to normalize.</param>
        /// <param name="languages">
        /// The languages whose diacritical marks should be replaced. If <see langword="null"/> or empty,
        /// <paramref name="sourceText"/> is returned unchanged.
        /// </param>
        /// <returns>The normalized text.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="sourceText"/> is <see langword="null"/>.</exception>
        public static string ReplaceDiacriticalMarks(this string sourceText, params Language[]? languages)
        {
            if (sourceText is null) throw new ArgumentNullException(nameof(sourceText));
            if (languages == null || languages.Length == 0) return sourceText;
            return LanguageNormalizer.ReplaceDiacriticalMarks(sourceText, languages);
        }
    }
}
