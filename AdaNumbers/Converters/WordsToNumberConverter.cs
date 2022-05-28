using System.Globalization;
using Ada.Numbers.Constants;
using Ada.Numbers.Utilities;

namespace Ada.Numbers.Converters;

public class WordsToNumberConverter
{
	private static readonly Dictionary<string, long> WordsToNumberMap = new()
	{
		{ WrittenNumbers.Zero, 0 },
		{ WrittenNumbers.One, 1 },
		{ WrittenNumbers.Two, 2 },
		{ WrittenNumbers.Three, 3 },
		{ WrittenNumbers.Four, 4 },
		{ WrittenNumbers.Five, 5 },
		{ WrittenNumbers.Six, 6 },
		{ WrittenNumbers.Seven, 7 },
		{ WrittenNumbers.Eight, 8 },
		{ WrittenNumbers.Nine, 9 },
		{ WrittenNumbers.Ten, 10 },
		{ WrittenNumbers.Eleven, 11 },
		{ WrittenNumbers.Twelve, 12 },
		{ WrittenNumbers.Thirteen, 13 },
		{ WrittenNumbers.Fourteen, 14 },
		{ WrittenNumbers.Fifteen, 15 },
		{ WrittenNumbers.Sixteen, 16 },
		{ WrittenNumbers.Seventeen, 17 },
		{ WrittenNumbers.Eighteen, 18 },
		{ WrittenNumbers.Nineteen, 19 },
		{ WrittenNumbers.Twenty, 20 },
		{ WrittenNumbers.Thirty, 30 },
		{ WrittenNumbers.Forty, 40 },
		{ WrittenNumbers.Fifty, 50 },
		{ WrittenNumbers.Sixty, 60 },
		{ WrittenNumbers.Seventy, 70 },
		{ WrittenNumbers.Eighty, 80 },
		{ WrittenNumbers.Ninety, 90 },
		{ WrittenNumbers.OneHundred, 100 },
		{ WrittenNumbers.OneHundredSingle, 100 },
		{ WrittenNumbers.TwoHundred, 200 },
		{ WrittenNumbers.ThreeHundred, 300 },
		{ WrittenNumbers.FourHundred, 400 },
		{ WrittenNumbers.FiveHundred, 500 },
		{ WrittenNumbers.SixHundred, 600 },
		{ WrittenNumbers.SevenHundred, 700 },
		{ WrittenNumbers.EightHundred, 800 },
		{ WrittenNumbers.NineHundred, 900 },
		{ WrittenNumbers.Thousand, (long)1e3 },
		{ WrittenNumbers.MillionSingular, (long)1e6 },
		{ WrittenNumbers.MillionPlural, (long)1e6 },
		{ WrittenNumbers.ThousandMillion, (long)1e9 },
		{ WrittenNumbers.BillionSingular, (long)1e12 },
		{ WrittenNumbers.BillionPlural, (long)1e12 }
	};

	public static string? Convert(string words)
	{
		var info = CultureInfo.CurrentCulture.TextInfo;
		var result = WordsToNumberMap.Resolve(info.ToTitleCase(words));

		if (result is not null)
			return result.ToString();

		string[] stringTokens = words.Split(" ");
		Stack<long?> numericTokens = new();

		foreach (var token in stringTokens)
		{
			var number = WordsToNumberMap.Resolve(token);

			if (number is not null)
			{
				if (IsToComputeMultiplier(token, numericTokens.Count))
				{
					var multiplier = FindMultiplier(ref numericTokens);
					number *= multiplier;
				}

				numericTokens.Push(number);
			}
			else
			{
				return Messages.InvalidNumber;
			}
		}

		return numericTokens.Sum().ToString();
	}

	private static bool IsToComputeMultiplier(string token, int numberOfNumericTokens)
	{
		return (token is WrittenNumbers.Thousand
			       or WrittenNumbers.MillionSingular or WrittenNumbers.MillionPlural
			       or WrittenNumbers.ThousandMillion
			       or WrittenNumbers.BillionSingular or WrittenNumbers.BillionPlural
			       or WrittenNumbers.TrillionSingular or WrittenNumbers.TrillionPlural)
		       && numberOfNumericTokens != 0;
	}

	private static long? FindMultiplier(ref Stack<long?> numericTokens)
	{
		var multiplier = numericTokens.Pop();

		while (numericTokens.Count != 0)
			multiplier += numericTokens.Pop();

		return multiplier;
	}
}