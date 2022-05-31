
namespace Ada.Numbers.Converters;

public static class WordsToNumberConverterExtensions
{
	public static string? ToNumber(this string words, bool useShortScale = false)
	{
		return WordsToNumberConverter.Convert(words, useShortScale);
	}
}
