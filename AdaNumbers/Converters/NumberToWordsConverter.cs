using System.Globalization;
using Ada.Numbers.Utilities;
using Ada.Numbers.Constants;

namespace Ada.Numbers.Converters;

public static class NumberToWordsConverter
{
	private const string Unsupported = "<Unsupported>";
	private const string DecimalSeparator = "Vírgula";
  private const byte Limit = 15;

	private static bool _useShortScale;

	private static readonly List<string> NumberTokens = new();

	public static string Convert(long number, bool useShortScale = false)
	{
		if (number.NumberOfDigits() > Limit)
			return Unsupported;

		_useShortScale = useShortScale;

		NumberTokens.Clear();
		return ResolveNumber(number);
	}

	public static string Convert(int number, bool useShortScale = false)
	{
		return Convert((long)number, useShortScale);
	}

	public static string Convert(byte number, bool useShortScale = false)
	{
		return Convert((long)number, useShortScale);
  }

	public static string Convert(decimal number, bool useShortScale = false)
	{
		var strNumber = number.ToString(CultureInfo.InvariantCulture).Split(".");
		var strIntegerPart = strNumber.First();
		var strDecimalPart = strNumber.Last();

		if (strIntegerPart.Length > Limit || strDecimalPart.Length > Limit)
			return Unsupported;

		_useShortScale = useShortScale;

		var integerPart = long.Parse(strIntegerPart);
		var decimalPart = long.Parse(strDecimalPart);

		NumberTokens.Clear();
		var result = ResolveNumber(integerPart);

		if (decimalPart == 0)
			return result;

		result += $" {DecimalSeparator} ";

		foreach (var dp in strDecimalPart)
		{
			if (dp != '0')
				break;

			result += "Zero ";
		}


		NumberTokens.Clear();
		result += ResolveNumber(decimalPart);

		return result;
	}

	public static string Convert(double number, bool useShortScale = false)
	{
		return Convert((decimal)number, useShortScale);
	}

	public static string Convert(float number, bool useShortScale = false)
	{
		return Convert((decimal)number, useShortScale);
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
			NumberCategory.ThousandMiliions => ThousandMillions(number),
			NumberCategory.Billion => Billions(number),
			_ => result
		};

		if (result == string.Empty)
		{
			var strNumber = number.ToString();
			long firstDigits = 0, otherDigits = 0;

			var bridge = number.Bridge();

			var flagFirstDigits = false;

			if (numberCategory == NumberCategory.Hundred)
				flagFirstDigits = number != 100;

			firstDigits = long.Parse(strNumber[..bridge] + (new string('0', (byte)numberCategory)));
			otherDigits = long.Parse(strNumber[bridge..]);

			var flagOtherDigits = otherDigits != 100;

			ResolveNumber(firstDigits, flagFirstDigits);
			ResolveNumber(otherDigits, flagOtherDigits);
		}
		else
		{
			NumberTokens.Add(result);
		}

		return AddSeparatorsToNumber();
	}

	private static string AddSeparatorsToNumber()
	{
		List<string> numbersThatIgnoreSeparator = new()
		{
			WrittenNumbers.OneHundred,
			WrittenNumbers.TwoHundred,
			WrittenNumbers.ThreeHundred,
			WrittenNumbers.FourHundred,
			WrittenNumbers.FiveHundred,
			WrittenNumbers.SixHundred,
			WrittenNumbers.SevenHundred,
			WrittenNumbers.EightHundred,
			WrittenNumbers.NineHundred,
			WrittenNumbers.Thousand,
			WrittenNumbers.MillionSingular,
			WrittenNumbers.MillionPlural,
			WrittenNumbers.ThousandMillion,
			WrittenNumbers.BillionSingular,
			WrittenNumbers.BillionPlural,
			WrittenNumbers.TrillionSingular,
			WrittenNumbers.TrillionPlural
		};

		string result = NumberTokens.First();

		for (var cursor = 1; cursor < NumberTokens.Count; cursor++)
		{
			var currentToken = NumberTokens[cursor];

			if (numbersThatIgnoreSeparator.Contains(currentToken))
				result += $" {currentToken}";
			else
				result += $" e {currentToken}";
		}

		return result;
	}

	private static string Unities(long number)
	{
		var results = new Dictionary<long, string>()
		{
			{ 0, WrittenNumbers.Zero },
			{ 1, WrittenNumbers.One },
			{ 2, WrittenNumbers.Two },
			{ 3, WrittenNumbers.Three },
			{ 4, WrittenNumbers.Four },
			{ 5, WrittenNumbers.Five },
			{ 6, WrittenNumbers.Six },
			{ 7, WrittenNumbers.Seven },
			{ 8, WrittenNumbers.Eight },
			{ 9, WrittenNumbers.Nine }
		};

		return results.Resolve(number);
	}

	private static string Tens(long number)
	{
		var results = new Dictionary<long, string>()
		{
			{ 10, WrittenNumbers.Ten },
			{ 11, WrittenNumbers.Eleven },
			{ 12, WrittenNumbers.Twelve },
			{ 13, WrittenNumbers.Thirteen },
			{ 14, WrittenNumbers.Fourteen },
			{ 15, WrittenNumbers.Fifteen },
			{ 16, WrittenNumbers.Sixteen },
			{ 17, WrittenNumbers.Seventeen },
			{ 18, WrittenNumbers.Eighteen },
			{ 19, WrittenNumbers.Nineteen },

			{ 20, WrittenNumbers.Twenty },
			{ 30, WrittenNumbers.Thirty },
			{ 40, WrittenNumbers.Forty },
			{ 50, WrittenNumbers.Fifty },
			{ 60, WrittenNumbers.Sixty },
			{ 70, WrittenNumbers.Seventy },
			{ 80, WrittenNumbers.Eighty },
			{ 90, WrittenNumbers.Ninety }
		};

		return results.Resolve(number);
	}

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

	private static string Thousands(long number)
	{
		return EvaluateThousandsAndOver(number, (long)1e3, WrittenNumbers.Thousand, WrittenNumbers.Thousand);
	}

	private static string Millions(long number)
	{
		return EvaluateThousandsAndOver(number, (long)1e6, WrittenNumbers.MillionSingular, WrittenNumbers.MillionPlural);
	}

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
