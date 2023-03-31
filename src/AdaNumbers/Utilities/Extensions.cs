using System.Globalization;

namespace Ada.Numbers.Utilities;

/// <summary>
/// A collection of number categories based on the number of digits a number has: <para/>
///  <br/> - Unity: 1;
///  <br/> - Ten: 2;
///  <br/> - Hundred: 3;
///  <br/> - Thousand: 4 to 6;
///  <br/> - Million: 7 to 9;
///  <br/> - Thousand Millions: 10 to 12;
///  <br/> - Billion: 13 to 15. <para/>
///  <br/> The collection takes into account the long scale.
/// </summary>
public enum NumberCategory
{
	Unity = 0,
	Ten = 1,
	Hundred = 2,
	Thousand = 3,
	Million = 6,
	ThousandMillions = 9,
	Billion = 12
}

public static class Extensions
{
	internal static string Resolve(this Dictionary<long, string> pair, long number)
	{
		try
		{
			return pair[number];
		}
		catch (KeyNotFoundException)
		{
			return string.Empty;
		}
	}

	internal static long? Resolve(this Dictionary<string, long> pair, string words)
	{
		try
		{
			return pair[words];
		}
		catch (KeyNotFoundException)
		{
			return null;
		}
	}

	/// <summary>
	/// Computes the how many digits a number has
	/// </summary>
	/// <param name="number">The number whose number of digits we want to know</param>
	/// <returns> The number of digits of "number"</returns>
	public static byte NumberOfDigits(this long number) =>
		(byte)number.ToString().Length;

	/// <summary>
	/// Evaluates the category a number belongs to.
	/// </summary>
	/// <param name="number">The number whose category we want to know</param>
	/// <returns>The category of the number in "NumberFormat" enum</returns>
	public static NumberCategory Category(this long number)
	{
		var result = NumberCategory.Unity;

		switch (number.NumberOfDigits())
		{
			case 2:
				result = NumberCategory.Ten;
				break;
			case 3:
				result = NumberCategory.Hundred;
				break;
			case 4:
			case 5:
			case 6:
				result = NumberCategory.Thousand;
				break;
			case 7:
			case 8:
			case 9:
				result = NumberCategory.Million;
				break;
			case 10:
			case 11:
			case 12:
				result = NumberCategory.ThousandMillions;
				break;
			case 13:
			case 14:
			case 15:
				result = NumberCategory.Billion;
				break;
		}

		return result;
	}

	public static byte Bridge(this long number)
	{
		var numberOfDigits = number.NumberOfDigits();

		byte bridge = numberOfDigits switch
		{
			5 or 8 or 11 or 14 => 2,
			6 or 9 or 12 or 15 => 3,
			_ => 1
		};

		return bridge;
	}

	/// <summary>
	/// Computes the how many digits a number has
	/// </summary>
	/// <param name="number">The number whose number of digits we want to know</param>
	/// <returns> The number of digits of "number"</returns>
	public static byte NumberOfDigits(this int number) =>
		NumberOfDigits((long)number);


	/// <summary>
	/// Evaluates the category a number belongs to.
	/// </summary>
	/// <param name="number">The number whose category we want to know</param>
	/// <returns>The category of the number in "NumberFormat" enum</returns>
	public static NumberCategory Category(this int number) =>
		Category((long)number);

	internal static byte Bridge(this int number) =>
		Bridge((long)number);

	/// <summary>
	/// Computes the how many digits a number has
	/// </summary>
	/// <param name="number">The number whose number of digits we want to know</param>
	/// <returns> The number of digits of "number"</returns>
	public static byte NumberOfDigits(this byte number)=>
		NumberOfDigits((long)number);

	/// <summary>
	/// Evaluates the category a number belongs to.
	/// </summary>
	/// <param name="number">The number whose category we want to know</param>
	/// <returns>The category of the number in "NumberFormat" enum</returns>
	public static NumberCategory Category(this byte number) =>
		Category((long)number);

	internal static byte Bridge(this byte number) =>
		Bridge((long)number);

	internal static string ToTitleCase(this string word) =>
		CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
}
