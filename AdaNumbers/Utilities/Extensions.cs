namespace Ada.Numbers.Utilities;

public enum NumberCategory
{
	Unity = 0,
	Ten = 1,
	Hundred = 2,
	Thousand = 3,
	Million = 6,
	ThousandMiliions = 9,
	Billion = 12
}

public static class Extensions
{
	public static string Resolve(this Dictionary<long, string> pair, long number)
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

	public static long? Resolve(this Dictionary<string, long> pair, string words)
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

	public static byte NumberOfDigits(this long number)
	{
		return (byte)number.ToString().Length;
	}

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
				result = NumberCategory.ThousandMiliions;
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
}
