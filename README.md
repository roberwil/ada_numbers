# Ada.Numbers

### Features:
 - It converts a number to its equivalent in written words, i.e. 123 to "cento e vinte três";
 - It converts a word to its equivalent in number, i.e. "cento e vinte dois" to "122".

### Specification

Available namespaces are:
- `Ada.Numbers.Converters` which contains the extension methods for conversion;
- `Ada.Numbers.Constants` which contains the constants used in conversions;
- `Ada.Numbers.Utilities` which contains some useful methods such as the number of digits and the category of the number.

`Ada.Numbers.Converters`

For `string`, there method is `.ToNumber(useShortScale)`. `useShortScale` is a boolean whose default
value is `false`.

Example:

```csharp
var number = "vinte e dois";
number.ToNumber() // > "22"
```

Check the method documentation for more details.

For numerical types (`long, int, byte, decimal, double and float`), the method is `.ToWords(useShortScale)`. `useShortScale` is a boolean whose default
value is `false`.


```csharp
var number = 22;
number.ToNumber() // > "Vinte e Dois"
```

Check the method documentation for more details.


`Ada.Numbers.Constants`

It includes the classes:
- `Messages`: for useful messages, check the class documentation for more details.
- `Separators`: for number separator, check the class documentation for more details.


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


