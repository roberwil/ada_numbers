namespace Ada.Numbers.Converters;

public static class NumberToWordsConverterExtensions
{
	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this long number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this int number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this byte number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this decimal number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this double number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <param name="useShortScale">Flag to enable the usage of the short scale for naming numbers</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this float number, bool useShortScale = false)
	{
		return NumberToWordsConverter.Convert(number, useShortScale);
	}
}
