# Wookashi.ExtraText
Wookashi.ExtraText is an open-source, cross-platform very simple plugin allows you replace language specific diacritic marks to unified used globally.

## Getting Started
Instalaltion and use is very simple.

### Installing
You can install plugin in two ways:<br/>
Use Nuget Package Manager and type command:
```
Install-Package Wookashi.ExtraText
```
Use Manage Nuget Packages from menu and search Wookashi.ExtraText.

## Running
Firstly add Wookashi.EtraText namespace.<br/>
Secondly you have new string extensions:
```
"SomeTEXT".ReplaceDiacriticalMarks()
```
or
```
"SomeTEXT".ReplaceDiacriticalMarks(Language language)
```
Language is Wookashi.ExtraText.Normalize.Enums.Language enum.<br/>
Example of use:
```
using System;
using Wookashi.ExtraText;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Jął ałć";
            Console.WriteLine(text.ReplaceDiacriticalMarks());
            Console.ReadKey();

            // Result: "Jal alc"
        }
    }
}
```

## Contributing
If you have some improvement ideas or want to fix something feel free to mail me at l.hryciuk@outlook.com.

## Authors
* **Lukas Hryciuk** - *Initial work* - [Wookashi](https://github.com/LukaszHr)
List of authors could be change ;)

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

