# Wookashi.ExtraText

## Overview
A .NET NuGet package that removes diacritical marks (accents) from text in a language-specific manner. It normalizes characters like "ą", "ü", "é" to their ASCII equivalents ("a", "u", "e") - useful for search, sorting, and data standardization.

## Project Structure
```
Wookashi.ExtraText/
├── Wookashi.ExtraText/                 # Main library project
│   ├── Normalize/
│   │   ├── Enums/
│   │   │   └── Language.cs             # Supported languages enum
│   │   ├── Implementation/
│   │   │   └── LanguageNormalizer.cs   # Core normalization logic (static)
│   │   └── Models/
│   │       └── LanguageDiacriticalMark.cs  # Character mappings (~400+)
│   ├── TextNormalization.cs            # Public API (extension methods)
│   └── Wookashi.ExtraText.csproj       # Project configuration
│
├── Wookashi.ExtraText.Tests/           # Unit tests project
│   ├── TextNormalizationTests.cs       # 100+ test cases
│   └── Wookashi.ExtraText.Tests.csproj
│
└── Wookashi.ExtraText.sln
```

## Key Files

| File | Purpose |
|------|---------|
| `TextNormalization.cs` | Public API with extension methods: `ReplaceDiacriticalMarks()`, `ReplaceDiacriticalMarks(Language)`, `ReplaceDiacriticalMarks(params Language[])` |
| `LanguageNormalizer.cs` | Internal static class with core replacement logic using StringBuilder |
| `LanguageDiacriticalMark.cs` | Static readonly list of mappings between diacritical characters and replacements |
| `Language.cs` | Enum of supported languages |

## Technologies
- **.NET Standard 2.0** - Cross-platform compatibility (supports .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- **.NET 10.0** - Test project runtime
- **XUnit 2.9.3** - Testing framework
- **StringBuilder** - Efficient string manipulation
- **C# Latest** - Modern language features

## Supported Languages (25)
1. Polish - 18 marks (ą, ć, ę, ł, ń, ó, ś, ź, ż)
2. German - 7 marks (ä, ö, ü, ß)
3. French - 30+ marks (à, â, é, è, ê, ë, ç, etc.)
4. Spanish - 14 marks (á, é, í, ó, ú, ü, ñ)
5. Swedish - 6 marks (å, ä, ö)
6. Slovak - 33 marks (á, č, ď, ľ, ň, ô, ŕ, š, ť, ý, ž, etc.)
7. Czech - 28 marks (á, č, ď, é, ě, í, ň, ó, ř, š, ť, ú, ů, ý, ž)
8. Hungarian - 18 marks (á, é, í, ó, ö, ő, ú, ü, ű)
9. Serbian (Latin) - 10 marks (č, ć, đ, š, ž)
10. Portuguese - 23 marks (á, à, â, ã, é, ê, í, ó, ô, õ, ú, ç)
11. Italian - 12 marks (à, è, é, ì, ò, ù)
12. Romanian - 10 marks (ă, â, î, ș, ț)
13. Turkish - 12 marks (ç, ğ, ı, İ, ö, ş, ü)
14. Danish - 6 marks (æ, ø, å)
15. Norwegian - 6 marks (æ, ø, å)
16. Finnish - 4 marks (ä, ö)
17. Icelandic - 20 marks (á, é, í, ó, ú, ý, ð, þ, æ, ö)
18. Croatian - 10 marks (č, ć, đ, š, ž)
19. Slovenian - 6 marks (č, š, ž)
20. Lithuanian - 18 marks (ą, č, ę, ė, į, š, ų, ū, ž)
21. Latvian - 22 marks (ā, č, ē, ģ, ī, ķ, ļ, ņ, š, ū, ž)
22. Estonian - 8 marks (ä, ö, ü, õ)
23. Catalan - 20 marks (à, é, è, í, ï, ó, ò, ú, ü, ç)
24. Dutch - 8 marks (ë, ï, é, ü)
25. Welsh - 14 marks (â, ê, î, ô, û, ŵ, ŷ)

## Architecture

### Design Patterns
- **Extension Methods** - Extends `string` class with normalization capabilities
- **Static Classes** - `LanguageNormalizer` (static) and `LanguageDiacriticalMark` (sealed) for performance
- **Static Data Pattern** - Centralized static readonly character mappings in `LanguageDiacriticalMark.Marks`
- **Strategy Pattern** - Three overloads for different normalization strategies

### Layers
1. **Extension Methods Layer** (`TextNormalization.cs`) - Public API
2. **Implementation Layer** (`LanguageNormalizer.cs`) - Core business logic
3. **Data Layer** (`LanguageDiacriticalMark.cs`) - Character mappings

## Usage Examples
```csharp
// Replace all diacritical marks (all languages)
"żółć".ReplaceDiacriticalMarks();  // Returns "zolc"

// Replace language-specific marks only
"über".ReplaceDiacriticalMarks(Language.German);  // Returns "ueber"

// Replace marks for multiple specific languages
"żółć über café".ReplaceDiacriticalMarks(Language.Polish, Language.German);  // Returns "zolc ueber café"
```

## Testing
- XUnit with `[Theory]` and `[InlineData]` attributes
- 100+ individual test cases across all 25 languages
- Success and failure scenarios
- Language isolation validation
- Null input validation
- Performance testing (< 1ms for 80-character string)

## Package Info
- **Version:** 2.0.0
- **License:** MIT
- **Target:** .NET Standard 2.0
