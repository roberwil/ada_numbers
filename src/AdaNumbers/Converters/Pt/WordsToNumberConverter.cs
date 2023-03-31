using System.Globalization;
using System.Text.RegularExpressions;
using Ada.Numbers.Constants;
using Ada.Numbers.Utilities;

namespace Ada.Numbers.Converters;

internal static class WordsToNumberConverter
{
	private static bool _useShortScale;

	private static void SelectScale() =>
		_useShortScale = Settings.Scale == Settings.Parameters.Scales.Short;

	internal static string? Convert(string word)
	{
		SelectScale();

		// Let the word be ins cute format: no extra spaces, first letter in capital
		word = Regex.Replace(word, "\\s+", " ").Trim().ToTitleCase();

		// Check whether the number has a decimal part (length of 2)
		var wordsToConvert = word.Split($" {Separators.DecimalSeparator} ");

		if (wordsToConvert.Length == 1)
			wordsToConvert = word.Split($" {Separators.DecimalSeparatorAlternative} ");

		switch (wordsToConvert.Length)
		{
			case 1:
				return ResolveWord(word, _useShortScale);
			case 2:
			{
				var countZeros = wordsToConvert.Last().Split().Select(w => w)
					.Count(w => w == WrittenNumbers.Zero);

				var wholePart = ResolveWord(wordsToConvert.First(), _useShortScale);
				var decimalPart = ResolveWord(wordsToConvert.Last().Replace(WrittenNumbers.Zero, ""), _useShortScale);

				if (wholePart == Messages.InvalidNumber || decimalPart == Messages.InvalidNumber)
					return Messages.InvalidNumber;

				if (countZeros > 0)
					decimalPart = $"{new string('0', countZeros)}{decimalPart}";

				var number = $"{wholePart}.{decimalPart}";

				return number;
			}
			default:
				return Messages.InvalidNumber;
		}
	}

	private static long? MapNumberFromScale(string word, bool useShortScale)
	{
		return useShortScale
			? WrittenNumbers.WordsToNumberMap.Resolve(word) ?? WrittenNumbers.WordsToNumberMapShorScale.Resolve(word)
			: WrittenNumbers.WordsToNumberMap.Resolve(word) ?? WrittenNumbers.WordsToNumberMapLongScale.Resolve(word);
	}


	private static string? ResolveWord(string word, bool useShortScale = false)
	{
		word = Regex.Replace(word, "\\s+", " ").Trim();

		// Try to get a direct match from the map
		var number = MapNumberFromScale(word, useShortScale);

		if (number is not null)
			return number.ToString();

		// It was not found a direct match, so, let's find that bastard
		string[] stringTokens = word.Split(" ");
		Stack<long?> numericTokens = new();

		// The algorithm consists on iterating every token so that to find its direct match
		// in the map and then stack it up. If the next number to be stacked requires a multiplier,
		// we find it and stack it up after popping the later numbers. When all the matches are found
		// The number is their sum
		for (var cursor = 0; cursor < stringTokens.Length; cursor++)
		{
			var token = stringTokens[cursor];

			// Check if separator is used correctly or is repeated
			switch (token)
			{
				case Separators.NumbersSeparator when cursor == 0 || cursor == stringTokens.Length - 1:
				case Separators.NumbersSeparator when WrittenNumbers.NumbersThatIgnoreSeparator.Contains(stringTokens[cursor + 1]):
				case Separators.NumbersSeparator when cursor > 0 && stringTokens[cursor - 1] == Separators.NumbersSeparator:
					return Messages.InvalidNumber;
				case Separators.NumbersSeparator:
					continue;
			}

			// Since there's no match for "milhão", "bilião", "trilião", etc., we add "Um" which is mapped
			token = IsToJoinOne(token) ? $"{WrittenNumbers.One} {token}" : token;

			var numberHasIncorrectOrNoSeparator =
				cursor > 0 &&
				!WrittenNumbers.NumbersThatIgnoreSeparator.Contains(token) &&
				stringTokens[cursor - 1] != Separators.NumbersSeparator;

			var numberIsInIncorrectShortScaleFormat =
				useShortScale && cursor > 0 && cursor < stringTokens.Length - 1 &&
				token == WrittenNumbers.Thousand &&
				WrittenNumbers.NotToCombineWithThousand.Contains(stringTokens[cursor + 1]);

			if (numberHasIncorrectOrNoSeparator || numberIsInIncorrectShortScaleFormat)
				return Messages.InvalidNumber;

			// Attempt to find a match
			number = MapNumberFromScale(token, useShortScale);

			if (number is null) return Messages.InvalidNumber;

			if (IsToComputeMultiplier(token, numericTokens.Count))
			{
				var multiplier = FindMultiplier(ref numericTokens);
				number *= multiplier;
			}

			numericTokens.Push(number);
		}

		return numericTokens.Sum().ToString();
	}

	private static bool IsToJoinOne(string token)
	{
		return token is not (WrittenNumbers.One or WrittenNumbers.Thousand) &&
		       (WrittenNumbers.MillionSingular.Contains(token) ||
		        WrittenNumbers.BillionSingular.Contains(token) ||
		        WrittenNumbers.TrillionSingular.Contains(token));
	}

	private static bool IsToComputeMultiplier(string token, int numberOfNumericTokens)
	{
		return token is WrittenNumbers.Thousand or WrittenNumbers.MillionSingular or
			       WrittenNumbers.MillionPlural or WrittenNumbers.BillionSingular or
			       WrittenNumbers.BillionPlural or WrittenNumbers.TrillionSingular or
			       WrittenNumbers.TrillionPlural
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
