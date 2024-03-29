using System.Globalization;
using Ada.Numbers.Utilities;
using Ada.Numbers.Constants;

namespace Ada.Numbers.Converters;

internal static class NumberToWordsConverterEn
{
	private static bool _useShortScale;
	private static readonly List<string> NumberTokens = new();

	private static void SelectScale() =>
		_useShortScale = Settings.Scale == Settings.Parameters.Scales.Short;

	internal static string Convert(long number)
	{
		if (number.NumberOfDigits() > Settings.Limit)
			return Messages.Unsupported;

		SelectScale();

		NumberTokens.Clear();
		return ResolveNumber(number);
	}

	internal static string Convert(decimal number)
	{
		SelectScale();

		var strNumber = number
			.ToString(CultureInfo.InvariantCulture)
			.Split(".");

		var strIntegerPart = strNumber.First();
		var strDecimalPart = strNumber.Length == 1 ? "0" : strNumber.Last();

		if (strIntegerPart.Length > Settings.Limit || strDecimalPart.Length > Settings.Limit)
			return Messages.Unsupported;

		var wholePart = long.Parse(strIntegerPart);
		var decimalPart = long.Parse(strDecimalPart);

		NumberTokens.Clear();
		var result = ResolveNumber(wholePart);

		if (decimalPart == 0) return result;

		result += $" {SeparatorsEn.DecimalSeparator.ToLower()} ";
		result = strDecimalPart
			.TakeWhile(dp => dp == '0')
			.Aggregate(result, (current, _) => current + $"{WrittenNumbersEn.Zero} ");

		NumberTokens.Clear();
		result += ResolveNumber(decimalPart);

		return result;
	}

	private static string ResolveNumber(long number)
	{
		var result = string.Empty;
		var numberCategory = number.Category();

		result = numberCategory switch
		{
			NumberCategory.Unity => Unities(number),
			NumberCategory.Ten => Tens(number),
			NumberCategory.Hundred => Hundreds(number),
			NumberCategory.Thousand => Thousands(number),
			NumberCategory.Million => Millions(number),
			NumberCategory.ThousandMillions => ThousandMillions(number),
			NumberCategory.Billion => Billions(number),
			_ => result
		};

		if (result == string.Empty)
		{
			var strNumber = number.ToString();
			var bridge = number.Bridge();

			var firstDigits = long.Parse(strNumber[..bridge] + new string('0', (byte)numberCategory));
			var otherDigits = long.Parse(strNumber[bridge..]);

			ResolveNumber(firstDigits);
			ResolveNumber(otherDigits);
		}
		else
			NumberTokens.Add(result);

		return NumberTokens.AddSeparatorsToNumber();
	}

	private static bool IsUnityOrTen(string number)
	{
		var result  = WrittenNumbersEn.WordsToNumberUnitiesAndTensMap.Resolve(number) is not null;
		return result ? result : number.Contains(SeparatorsEn.Dash);
	}

	private static string AddSeparatorsToNumber(this IReadOnlyList<string> numberTokens)
	{
		var result = numberTokens.First();

		for (var cursor = 1; cursor < numberTokens.Count; cursor++)
		{
			var currentToken = numberTokens[cursor];

			var isHundred = cursor + 1 < numberTokens.Count && IsUnityOrTen(currentToken) &&
			                (numberTokens[cursor + 1] == WrittenNumbersEn.Hundred  ||
			                 numberTokens[cursor + 1] == WrittenNumbersEn.Thousand ||
			                 numberTokens[cursor + 1] == WrittenNumbersEn.Million  ||
			                 numberTokens[cursor + 1] == WrittenNumbersEn.ThousandMillion ||
			                 numberTokens[cursor + 1] == WrittenNumbersEn.Billion  ||
			                 numberTokens[cursor + 1] == WrittenNumbersEn.Trillion);

			var addComma = cursor > 1 && isHundred;
			var noSeparator = WrittenNumbersEn.NumbersThatIgnoreSeparator.Contains(currentToken) || isHundred;

			if (addComma)
				result += $"{SeparatorsEn.Comma} {currentToken}";
			else if (noSeparator)
				result += $" {currentToken}";
			else
				result += $" {SeparatorsEn.NumbersSeparator.ToLower()} {currentToken}";
		}

		return result;
	}

	private static string Unities(long number) =>
		WrittenNumbersEn.NumbersToWordsMapUnities.Resolve(number);

	private static string Tens(long number)
	{
		var result = WrittenNumbersEn.NumbersToWordsMapTens.Resolve(number);

		if (result != string.Empty) return result;

		var bridge = number.Bridge();

		var ten = long.Parse(number.ToString()[..bridge]!)*10;
		var unity = long.Parse(number.ToString()[bridge..]!);

		result = $"{Tens(ten)}{SeparatorsEn.Dash}{Unities(unity).ToLower()}";
		return result;
	}

	private static string Hundreds(long number) =>
		EvaluateHundredsAndOver(number, (long)1e2, WrittenNumbersEn.Hundred);

	private static string Thousands(long number) =>
		EvaluateHundredsAndOver(number, (long)1e3, WrittenNumbersEn.Thousand);

	private static string Millions(long number) =>
		EvaluateHundredsAndOver(number, (long)1e6, WrittenNumbersEn.Million);


	private static string ThousandMillions(long number)
	{
		var qualifier = _useShortScale ? WrittenNumbersEn.Billion : WrittenNumbersEn.ThousandMillion;
		return EvaluateHundredsAndOver(number, (long)1e9, qualifier);
	}

	private static string Billions(long number)
	{
		var qualifier = _useShortScale ? WrittenNumbersEn.Trillion : WrittenNumbersEn.Billion;
		return EvaluateHundredsAndOver(number, (long)1e12, qualifier);
	}

	private static string EvaluateHundredsAndOver(long number, long categoryIdentifier, string qualifier)
	{
		if (number%categoryIdentifier != 0)
			return string.Empty;

		var partialNumber = long.Parse(number.ToString()[..number.Bridge()]);

		ResolveNumber(partialNumber);
		return qualifier;
	}

}

