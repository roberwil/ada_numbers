using System.Globalization;
using Ada.Numbers.Utilities;
using Ada.Numbers.Constants;

namespace Ada.Numbers.Converters;

internal static class NumberToWordsConverter
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

		if (decimalPart == 0)
			return result;

		result += $" {Separators.DecimalSeparator.ToLower()} ";
		result = strDecimalPart
			.TakeWhile(dp => dp == '0')
			.Aggregate(result, (current, _) => current + $"{WrittenNumbers.Zero} ");

		NumberTokens.Clear();
		result += ResolveNumber(decimalPart);

		return result;
	}

	private static string ResolveNumber(long number, bool flag = false)
	{
		var result = string.Empty;
		var numberCategory = number.Category();

		result = numberCategory switch
		{
			NumberCategory.Unity => Unities(number),
			NumberCategory.Ten => Tens(number),
			NumberCategory.Hundred => Hundreds(number, flag),
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
			var flagFirstDigits = false;

			if (numberCategory == NumberCategory.Hundred)
				flagFirstDigits = number != 100;

			var firstDigits = long.Parse(strNumber[..bridge] + new string('0', (byte)numberCategory));
			var otherDigits = long.Parse(strNumber[bridge..]);

			var flagOtherDigits = otherDigits != 100;

			ResolveNumber(firstDigits, flagFirstDigits);
			ResolveNumber(otherDigits, flagOtherDigits);
		}
		else
			NumberTokens.Add(result);


		return NumberTokens.AddSeparatorsToNumber();
	}

	private static string AddSeparatorsToNumber(this IReadOnlyList<string> numberTokens)
	{
		var result = numberTokens.First();

		for (var cursor = 1; cursor < numberTokens.Count; cursor++)
		{
			var currentToken = numberTokens[cursor];

			if (WrittenNumbers.NumbersThatIgnoreSeparator.Contains(currentToken))
				result += $" {currentToken}";
			else
				result += $" {Separators.NumbersSeparator.ToLower()} {currentToken}";
		}

		return result;
	}

	private static string Unities(long number) =>
		WrittenNumbers.NumbersToWordsMapUnities.Resolve(number);

	private static string Tens(long number) =>
		WrittenNumbers.NumbersToWordsMapTens.Resolve(number);

	private static string Hundreds(long number, bool isCent = false)
	{
		var results = new Dictionary<long, string>
		{
			{ 200, WrittenNumbers.TwoHundred },
			{ 300, WrittenNumbers.ThreeHundred },
			{ 400, WrittenNumbers.FourHundred },
			{ 500, WrittenNumbers.FiveHundred },
			{ 600, WrittenNumbers.SixHundred },
			{ 700, WrittenNumbers.SevenHundred },
			{ 800, WrittenNumbers.EightHundred },
			{ 900, WrittenNumbers.NineHundred },
			{ 100, isCent ? WrittenNumbers.OneHundred : WrittenNumbers.OneHundredSingle }
		};

		return results.Resolve(number);
	}

	private static string Thousands(long number) =>
		EvaluateThousandsAndOver(number, (long)1e3, WrittenNumbers.Thousand, WrittenNumbers.Thousand);

	private static string Millions(long number) =>
		EvaluateThousandsAndOver(number, (long)1e6, WrittenNumbers.MillionSingular, WrittenNumbers.MillionPlural);

	private static string ThousandMillions(long number)
	{
		var singular = _useShortScale ? WrittenNumbers.BillionSingular : WrittenNumbers.ThousandMillion;
		var plural = _useShortScale ? WrittenNumbers.BillionPlural : WrittenNumbers.ThousandMillion;

		return EvaluateThousandsAndOver(number, (long)1e9, singular, plural);
	}

	private static string Billions(long number)
	{
		var singular = _useShortScale ? WrittenNumbers.TrillionSingular : WrittenNumbers.BillionSingular;
		var plural = _useShortScale ? WrittenNumbers.TrillionPlural : WrittenNumbers.BillionPlural;

		return EvaluateThousandsAndOver(number, (long)1e12, singular, plural);
	}

	private static string EvaluateThousandsAndOver(long number, long categoryIdentifier, string singular, string plural)
	{
		if (number == categoryIdentifier)
			return singular;

		if (number%categoryIdentifier != 0)
			return string.Empty;

		var partialNumber = long.Parse(number.ToString()[..number.Bridge()]);

		ResolveNumber(partialNumber);
		return plural;
	}

}
