
namespace Ada.Numbers.Converters;

public static class WordsToNumberConverterExtensions
{
	/// <summary>
	/// Converts a word, i.e. "cento e vinte e dois", to "122"
	/// </summary>
	/// <param name="word"> The word to be converted</param>
	/// <param name="useShortScale"> Use short scale numbering</param>
	/// <returns>The string which corresponds to the number of the converted word or "InvalidNumber"</returns>
	public static string? ToNumber(this string word, bool useShortScale = false)
	{
		return WordsToNumberConverter.Convert(word, useShortScale);
	}
}
