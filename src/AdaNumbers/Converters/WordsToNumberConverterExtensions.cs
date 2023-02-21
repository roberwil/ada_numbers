
using Ada.Numbers.Utilities;

namespace Ada.Numbers.Converters;

public static class WordsToNumberConverterExtensions
{
	/// <summary>
	/// Converts a word to a number, i.e. "cento e vinte e dois" to "122".
	/// </summary>
	/// <param name="word">The word to be converted</param>
	/// <returns>
	/// The string which corresponds to the number of the converted word or a message of type "Messages" as in Ada.Numbers.Constants namespace
	/// </returns>
	public static string? ToNumber(this string word)
	{
		return Settings.Language switch
		{
			Settings.Parameters.Languages.Pt => WordsToNumberConverter.Convert(word),
			Settings.Parameters.Languages.En => WordsToNumberConverterEn.Convert(word),
			_ => WordsToNumberConverter.Convert(word)
		};
	}
}
