
namespace Ada.Numbers.Converters;

public static class WordsToNumberConverterExtensions
{
	public static string? ToNumber(this string words)
	{
		return WordsToNumberConverter.Convert(words);
	}
}
