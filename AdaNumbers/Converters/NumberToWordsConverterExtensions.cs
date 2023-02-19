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
		return NumberToWordsConverter.Convert(number);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this int number)
	{
		return NumberToWordsConverter.Convert(number);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this byte number)
	{
		return NumberToWordsConverter.Convert(number);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this decimal number)
	{
		return NumberToWordsConverter.Convert(number);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this double number)
	{
		return NumberToWordsConverter.Convert((decimal)number);
	}

	/// <summary>
	/// Converts "number" to words, i.e. 123 to "cento e vinte três".
	/// </summary>
	/// <param name="number">The number to be converted</param>
	/// <returns>The equivalent in words of "number" or a message of type "Messages" as in Ada.Numbers.Constants namespace</returns>
	public static string ToWords(this float number)
	{
		return NumberToWordsConverter.Convert((decimal)number);
	}
}
