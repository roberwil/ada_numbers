using System.Globalization;
using Ada.Numbers.Utilities;
using Ada.Numbers.Constants;

namespace Ada.Numbers.Converters;

public static class NumberToWordsConverterExtensions
{
	public static string ToWords(this long number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	public static string ToWords(this int number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	public static string ToWords(this byte number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	public static string ToWords(this decimal number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	public static string ToWords(this double number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	public static string ToWords(this float number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}
}
