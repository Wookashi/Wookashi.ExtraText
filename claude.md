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
│   │   │   └── LanguageNormalizer.cs   # Core normalization logic
│   │   └── Models/
│   │       └── LanguageDiacriticalMark.cs  # Character mappings (~200+)
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
| `TextNormalization.cs` | Public API with extension methods: `ReplaceDiacriticalMarks()` and `ReplaceDiacriticalMarks(Language)` |
| `LanguageNormalizer.cs` | Internal sealed class with core replacement logic using StringBuilder |
| `LanguageDiacriticalMark.cs` | Defines mappings between diacritical characters and replacements |
| `Language.cs` | Enum of supported languages |

## Technologies
- **.NET Standard 2.0** - Cross-platform compatibility (supports .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- **.NET 9.0** - Test project runtime
- **XUnit 2.9.3** - Testing framework
- **StringBuilder** - Efficient string manipulation
- **C# Latest** - Modern language features

## Supported Languages (9)
1. Polish - 18 marks (ą, ć, ę, ł, ń, ó, ś, ź, ż)
2. German - 7 marks (ä, ö, ü, ß)
3. French - 30+ marks (à, â, é, è, ê, ë, ç, etc.)
4. Spanish - 14 marks (á, é, í, ó, ú, ü, ñ)
5. Swedish - 6 marks (å, ä, ö)
6. Slovak - 33 marks (á, č, ď, ľ, ň, ô, ŕ, š, ť, ý, ž, etc.)
7. Czech - 28 marks (á, č, ď, é, ě, í, ň, ó, ř, š, ť, ú, ů, ý, ž)
8. Hungarian - 18 marks (á, é, í, ó, ö, ő, ú, ü, ű)
9. Serbian (Latin) - 10 marks (č, ć, đ, š, ž)

## Architecture

### Design Patterns
- **Extension Methods** - Extends `string` class with normalization capabilities
- **Sealed Classes** - `LanguageNormalizer` and `LanguageDiacriticalMark` for performance
- **Static Data Pattern** - Centralized character mappings in `LanguageDiacriticalMark.Marks`
- **Strategy Pattern** - Two overloads for different normalization strategies

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
```

## Testing
- XUnit with `[Theory]` and `[InlineData]` attributes
- 100+ individual test cases across 9 languages
- Success and failure scenarios
- Language isolation validation
- Performance testing (< 1ms for 80-character string)

## Package Info
- **Version:** 2.0.0
- **License:** MIT
- **Target:** .NET Standard 2.0
