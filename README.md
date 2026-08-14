# Wookashi.ExtraText

[![NuGet](https://img.shields.io/nuget/v/Wookashi.ExtraText.svg)](https://www.nuget.org/packages/Wookashi.ExtraText)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.0-blue.svg)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

A lightweight, cross-platform .NET library for removing diacritical marks (accents) from text in a language-specific manner. Perfect for search functionality, sorting, URL slugs, or data standardization.

## Features

- Supports **9 languages** with 200+ character mappings
- Simple extension methods on `string`
- Cross-platform (.NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- High performance using `StringBuilder`
- No external dependencies

## Installation

### Package Manager
```
Install-Package Wookashi.ExtraText
```

### .NET CLI
```
dotnet add package Wookashi.ExtraText
```

### PackageReference
```xml
<PackageReference Include="Wookashi.ExtraText" Version="2.0.0" />
```

## Usage

Add the namespace:
```csharp
using Wookashi.ExtraText;
```

### Replace All Diacritical Marks
Replaces diacritical marks from all supported languages:
```csharp
"żółć".ReplaceDiacriticalMarks();     // Returns "zolc"
"café".ReplaceDiacriticalMarks();     // Returns "cafe"
"Müller".ReplaceDiacriticalMarks();   // Returns "Mueller"
```

### Replace Language-Specific Marks
Replaces only marks from the specified language:
```csharp
using Wookashi.ExtraText.Normalize.Enums;

"über".ReplaceDiacriticalMarks(Language.German);    // Returns "ueber"
"żółć".ReplaceDiacriticalMarks(Language.Polish);    // Returns "zolc"
"señor".ReplaceDiacriticalMarks(Language.Spanish);  // Returns "senor"
```

### Complete Example
```csharp
using System;
using Wookashi.ExtraText;
using Wookashi.ExtraText.Normalize.Enums;

class Program
{
    static void Main()
    {
        var polishText = "Zażółć gęślą jaźń";
        var germanText = "Größe über alles";

        // Replace all diacritics
        Console.WriteLine(polishText.ReplaceDiacriticalMarks());
        // Output: "Zazolc gesla jazn"

        // Replace only German-specific diacritics
        Console.WriteLine(germanText.ReplaceDiacriticalMarks(Language.German));
        // Output: "Groesse ueber alles"
    }
}
```

## Supported Languages

| Language | Example Characters | Replacement |
|----------|-------------------|-------------|
| **Polish** | ą, ć, ę, ł, ń, ó, ś, ź, ż | a, c, e, l, n, o, s, z, z |
| **German** | ä, ö, ü, ß | ae, oe, ue, ss |
| **French** | à, â, é, è, ê, ë, ç, î, ï, ô, ù, û | a, a, e, e, e, e, c, i, i, o, u, u |
| **Spanish** | á, é, í, ó, ú, ü, ñ | a, e, i, o, u, u, n |
| **Swedish** | å, ä, ö | a, a, o |
| **Slovak** | á, č, ď, ľ, ň, ô, ŕ, š, ť, ý, ž | a, c, d, l, n, o, r, s, t, y, z |
| **Czech** | á, č, ď, é, ě, í, ň, ó, ř, š, ť, ú, ů, ý, ž | a, c, d, e, e, i, n, o, r, s, t, u, u, y, z |
| **Hungarian** | á, é, í, ó, ö, ő, ú, ü, ű | a, e, i, o, o, o, u, u, u |
| **Serbian (Latin)** | č, ć, đ, š, ž | c, c, d, s, z |

All languages include both lowercase and uppercase variants.

## Use Cases

- **Search engines** - Normalize user input and indexed content for accent-insensitive search
- **URL slugs** - Generate clean URLs from titles containing special characters
- **Data deduplication** - Compare records that may have inconsistent diacritic usage
- **File naming** - Create safe filenames from user-provided text
- **Sorting** - Normalize text for consistent alphabetical ordering

## Contributing

Contributions are welcome! If you have suggestions, bug reports, or want to add support for more languages:

1. Fork the repository
2. Create a feature branch
3. Submit a pull request

Or contact me at l.hryciuk@outlook.com

## Authors

* **Lukas Hryciuk** - [Wookashi](https://github.com/LukaszHr)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
