
namespace Ada.Numbers.Converters;

public static class WordsToNumberConverterExtensions
{
	/// <summary>
	/// Converts a word to a number, i.e. "cento e vinte e dois" to "122".
	/// </summary>
	/// <param name="word">The word to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>
	/// The string which corresponds to the number of the converted word or a message of type "Messages" as in Ada.Numbers.Constants namespace
	/// </returns>
	public static string? ToNumber(this string word, bool useShortScale = false)
	{
		return WordsToNumberConverter.Convert(word, useShortScale);
	}
}
