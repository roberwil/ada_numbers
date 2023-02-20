using Ada.Numbers.Utilities;

namespace Ada.Numbers.Converters;

public static class NumberToWordsConverterExtensions
{
	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this long number)
	{
		return Settings.Language switch
		{
			Settings.Parameters.Languages.Pt => NumberToWordsConverter.Convert(number),
			Settings.Parameters.Languages.En => NumberToWordsConverterEn.Convert(number),
			_ => NumberToWordsConverter.Convert(number)
		};
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this int number)
	{
		long l = number;
		return l.ToWords();
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this byte number)
	{
		long l = number;
		return l.ToWords();
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this decimal number)
	{
		return Settings.Language switch
		{
			Settings.Parameters.Languages.Pt => NumberToWordsConverter.Convert(number),
			Settings.Parameters.Languages.En => NumberToWordsConverterEn.Convert(number),
			_ => NumberToWordsConverter.Convert(number)
		};
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this double number)
	{
		var d = (decimal)number;
		return d.ToWords();
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this float number)
	{
		var d = (decimal)number;
		return d.ToWords();
	}
}
