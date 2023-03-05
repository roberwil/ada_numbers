# Ada.Numbers

**Find the package at nuget [here](https://www.nuget.org/packages/Ada.Numbers/)**.

### Features:
 - It converts a number to its equivalent in written words, i.e. 123 to "cento e vinte três" or 123 to
"one hundred and twenty-three" depending on the chosen language;
 - It converts a word to its equivalent in number, i.e. "cento e vinte dois" to "122" or "one hundred and twenty-two"
to "122".

**Note: `ada.numbers` supports numbers with a maximum of 15 digits.**

### Specification

Available namespaces are:
- `Ada.Numbers.Settings` which contains the settings for the converters;
- `Ada.Numbers.Converters` which contains the extension methods for conversion;
- `Ada.Numbers.Constants` which contains the constants used in conversions;
- `Ada.Numbers.Utilities` which contains some useful methods such as the number of digits and the category of the number.

`Ada.Numbers.Settings`

Used to set the parameters of the converters. Available parameters are:

- Language;
- Scale.

To set the **language**, it is done as follows:

```csharp
Settings.Language = Settings.Parameters.Languages.En //Now, converters will use English
```

To set the **scale**, it is done as follows:

```csharp
Settings.Scale = Settings.Parameters.Scales.Short //Now, converters will use Short Scale
```

To learn more about scales, read [this](https://en.wikipedia.org/wiki/Long_and_short_scales).

The Settings are global, meaning that once they are set, every operation is affected, so, in order to
have a different behavior, the Settings must be explicitly set.
Per default, Language is **Portuguese** and the Scale is **Long**.

`Ada.Numbers.Converters`

For `string`, the method is `.ToNumber()`.

Examples:

```csharp
var number = "vinte e dois";
number.ToNumber() // > "22"

Settings.Language = Settings.Parameters.Languages.En //Now, converters will use English
number = "twenty-two";
number.ToNumber(); // > "22"
```

Check the method documentation for more details.

For numerical types (`long, int, byte, decimal, double and float`), the method is `.ToWords()`.


```csharp
var number = 22;
number.ToWords() // > "Vinte e Dois"

Settings.Language = Settings.Parameters.Languages.En //Now, converters will use English
var number = 22;
number.ToWords() // > "Twenty-two"
```

Check the method documentation for more details.


`Ada.Numbers.Constants`

It includes the classes:
- `Messages`: for useful messages, check the class documentation for more details.
- `Separators`: for number separator in Portuguese, check the class documentation for more details.
- `SeparatorsEn`: for number separator in English, check the class documentation for more details.


`Ada.Numbers.Utilities`

It includes extension methods for:
- `.NumberOfDigits()` available for `long, int and byte`: it returns the number of digits a number has.

```csharp
var number = 22;
number.NumberOfDigits() // > 2
```

- `.Category()` available for `long, int and byte`: it returns the the category of the number.

```csharp
var number = 22;
number.Category() // > NumberCategory.Ten
```

`NumberCategory` is an enum, check its documentation for more details.


