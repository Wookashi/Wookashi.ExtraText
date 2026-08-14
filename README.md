# Wookashi.ExtraText

[![NuGet](https://img.shields.io/nuget/v/Wookashi.ExtraText.svg)](https://www.nuget.org/packages/Wookashi.ExtraText)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.0-blue.svg)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

A lightweight, cross-platform .NET library for removing diacritical marks (accents) from text in a language-specific manner. Perfect for search functionality, sorting, URL slugs, or data standardization.

## Features

- Supports **25 languages** with 300+ character mappings
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
<PackageReference Include="Wookashi.ExtraText" Version="2.3.0" />
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
"Müller".ReplaceDiacriticalMarks();   // Returns "Muller"
```

> **Note:** A few characters (`ä`, `ö`, `ü`) are transliterated differently depending on language —
> German uses the `ae`/`oe`/`ue` digraph convention, while every other supported language that has
> these letters maps them to a single plain letter. When no language is specified, these characters
> always resolve to the plain letter (`a`/`o`/`u`) for a deterministic, language-agnostic result. To
> get German's digraph convention, call `ReplaceDiacriticalMarks(Language.German)` explicitly (see
> below).

### Replace Language-Specific Marks
Replaces only marks from the specified language:
```csharp
using Wookashi.ExtraText.Normalize.Enums;

"über".ReplaceDiacriticalMarks(Language.German);    // Returns "ueber"
"żółć".ReplaceDiacriticalMarks(Language.Polish);    // Returns "zolc"
"señor".ReplaceDiacriticalMarks(Language.Spanish);  // Returns "senor"
```

### Replace Marks for Multiple Languages
Replaces marks from a specific set of languages only:
```csharp
using Wookashi.ExtraText.Normalize.Enums;

"żółć über café".ReplaceDiacriticalMarks(Language.Polish, Language.German);
// Returns "zolc ueber café"  (French 'é' is untouched)
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
| **French** | à, â, é, è, ê, ë, ç, î, ï, ô, ù, û, œ, æ | a, a, e, e, e, e, c, i, i, o, u, u, oe, ae |
| **Spanish** | á, é, í, ó, ú, ü, ñ | a, e, i, o, u, u, n |
| **Swedish** | å, ä, ö | a, a, o |
| **Slovak** | á, ä, č, ď, é, í, ĺ, ľ, ň, ó, ô, ŕ, š, ť, ú, ý, ž | a, a, c, d, e, i, l, l, n, o, o, r, s, t, u, y, z |
| **Czech** | á, č, ď, é, ě, í, ň, ó, ř, š, ť, ú, ů, ý, ž | a, c, d, e, e, i, n, o, r, s, t, u, u, y, z |
| **Hungarian** | á, é, í, ó, ö, ő, ú, ü, ű | a, e, i, o, o, o, u, u, u |
| **Serbian** | č, ć, đ, š, ž | c, c, d, s, z |
| **Portuguese** | á, à, â, ã, é, ê, í, ó, ô, õ, ú, ç | a, a, a, a, e, e, i, o, o, o, u, c |
| **Italian** | à, è, é, ì, ò, ù | a, e, e, i, o, u |
| **Romanian** | ă, â, î, ș, ț | a, a, i, s, t |
| **Turkish** | ç, ğ, ı, İ, ö, ş, ü | c, g, i, I, o, s, u |
| **Danish** | æ, ø, å | ae, o, a |
| **Norwegian** | æ, ø, å | ae, o, a |
| **Finnish** | ä, ö | a, o |
| **Icelandic** | á, é, í, ó, ú, ý, ð, þ, æ, ö | a, e, i, o, u, y, d, th, ae, o |
| **Croatian** | č, ć, đ, š, ž | c, c, d, s, z |
| **Slovenian** | č, š, ž | c, s, z |
| **Lithuanian** | ą, č, ę, ė, į, š, ų, ū, ž | a, c, e, e, i, s, u, u, z |
| **Latvian** | ā, č, ē, ģ, ī, ķ, ļ, ņ, š, ū, ž | a, c, e, g, i, k, l, n, s, u, z |
| **Estonian** | ä, ö, ü, õ | a, o, u, o |
| **Catalan** | à, é, è, í, ï, ó, ò, ú, ü, ç | a, e, e, i, i, o, o, u, u, c |
| **Dutch** | ë, ï, é, ü | e, i, e, u |
| **Welsh** | â, ê, î, ô, û, ŵ, ŷ | a, e, i, o, u, w, y |

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

### Releasing (maintainers)

Publishing to NuGet is automated via GitHub Actions (`.github/workflows/publish.yml`).
To ship a release:

1. Bump `<Version>` in `Wookashi.ExtraText/Wookashi.ExtraText.csproj` (and update `PackageReleaseNotes`)
   and merge that change into `main`.
2. Tag the released commit with a matching `vX.Y.Z` version (e.g. `git tag v2.3.0 && git push origin v2.3.0`).

The workflow verifies the tag points at a commit on `main` and that the tag matches the csproj
`<Version>` (it fails fast otherwise), builds, runs the test suite, packs the library, and pushes
it to nuget.org.

Publishing uses [NuGet Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing)
(OIDC) instead of a long-lived API key — no NuGet secret to rotate. One-time setup:

1. On nuget.org, go to your username → **Trusted Publishing** → add a policy with:
   - **Repository Owner:** the GitHub org/user (e.g. `Wookashi`)
   - **Repository:** `Wookashi.ExtraText`
   - **Workflow File:** `publish.yml` (file name only, not the `.github/workflows/` path)
   - **Environment:** leave empty (this workflow doesn't use a GitHub Actions environment)
2. In the GitHub repo, add a repository secret named `NUGET_USER` containing your nuget.org
   **username** (profile name, not email) under **Settings → Secrets and variables → Actions**.

No other secret is needed — the workflow exchanges a short-lived GitHub OIDC token for a
temporary (1 hour) nuget.org API key at publish time.

## Authors

* **Lukas Hryciuk** - [Wookashi](https://github.com/LukaszHr)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
