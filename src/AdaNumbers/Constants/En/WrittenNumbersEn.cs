namespace Ada.Numbers.Constants;

internal abstract class WrittenNumbersEn
{
	internal const string Zero = "Zero";
	private const string One = "One";
	private const string Two = "Two";
	private const string Three = "Three";
	private const string Four = "Four";
	private const string Five = "Five";
	private const string Six = "Six";
	private const string Seven = "Seven";
	private const string Eight = "Eight";
	private const string Nine = "Nine";

	private const string Ten = "Ten";
	private const string Eleven = "Eleven";
	private const string Twelve = "Twelve";
	private const string Thirteen = "Thirteen";
	private const string Fourteen = "Fourteen";
	private const string Fifteen = "Fifteen";
	private const string Sixteen = "Sixteen";
	private const string Seventeen = "Seventeen";
	private const string Eighteen = "Eighteen";
	private const string Nineteen = "Nineteen";

	private const string Twenty = "Twenty";
	private const string Thirty = "Thirty";
	private const string Forty = "Forty";
	private const string Fifty = "Fifty";
	private const string Sixty = "Sixty";
	private const string Seventy = "Seventy";
	private const string Eighty = "Eighty";
	private const string Ninety = "Ninety";

	internal const string Hundred = "Hundred";
	internal const string Thousand = "Thousand";
	internal const string Million = "Million";
	internal const string ThousandMillion = "Thousand Million";
	internal const string Billion = "Billion";
	internal const string Trillion = "Trillion";

	internal static readonly List<string> NumbersThatIgnoreSeparator = new()
	{
		Hundred, Thousand, Million,
		ThousandMillion, Billion, Trillion
	};

	internal static readonly List<string> UnitiesThatCombineWithSeparator = new()
	{
		Twenty, Thirty, Forty, Fifty,
		Sixty, Seventy, Eighty, Ninety
	};


	internal static readonly Dictionary<string, long> WordsToNumberMap = new()
	{
		{ Zero, 0 },
		{ One, 1 },
		{ Two, 2 },
		{ Three, 3 },
		{ Four, 4 },
		{ Five, 5 },
		{ Six, 6 },
		{ Seven, 7 },
		{ Eight, 8 },
		{ Nine, 9 },
		{ Ten, 10 },
		{ Eleven, 11 },
		{ Twelve, 12 },
		{ Thirteen, 13 },
		{ Fourteen, 14 },
		{ Fifteen, 15 },
		{ Sixteen, 16 },
		{ Seventeen, 17 },
		{ Eighteen, 18 },
		{ Nineteen, 19 },
		{ Twenty, 20 },
		{ Thirty, 30 },
		{ Forty, 40 },
		{ Fifty, 50 },
		{ Sixty, 60 },
		{ Seventy, 70 },
		{ Eighty, 80 },
		{ Ninety, 90 },
		{ Hundred, 100 },
		{ Thousand, (long)1e3 },
		{ Million, (long)1e6 }
	};

	internal static readonly Dictionary<string, long> WordsToNumberUnitiesAndTensMap = new()
	{
		{ Zero, 0 },
		{ One, 1 },
		{ Two, 2 },
		{ Three, 3 },
		{ Four, 4 },
		{ Five, 5 },
		{ Six, 6 },
		{ Seven, 7 },
		{ Eight, 8 },
		{ Nine, 9 },
		{ Ten, 10 },
		{ Eleven, 11 },
		{ Twelve, 12 },
		{ Thirteen, 13 },
		{ Fourteen, 14 },
		{ Fifteen, 15 },
		{ Sixteen, 16 },
		{ Seventeen, 17 },
		{ Eighteen, 18 },
		{ Nineteen, 19 },
		{ Twenty, 20 },
		{ Thirty, 30 },
		{ Forty, 40 },
		{ Fifty, 50 },
		{ Sixty, 60 },
		{ Seventy, 70 },
		{ Eighty, 80 },
		{ Ninety, 90 },
	};

	internal static readonly Dictionary<string, long> WordsToNumberMapLongScale = new()
	{
		{ ThousandMillion, (long)1e9 },
		{ Billion, (long)1e12 }
	};

	internal static readonly Dictionary<string, long> WordsToNumberMapShorScale = new()
	{
		{ Billion, (long)1e9 },
		{ Trillion, (long)1e12 },
	};

	internal static readonly List<string> NotToCombineWithThousand = new()
	{
		Million,
		Billion,
		Trillion
	};

	internal static readonly Dictionary<long, string> NumbersToWordsMapUnities = new()
	{
		{ 0, Zero },
		{ 1, One },
		{ 2, Two },
		{ 3, Three },
		{ 4, Four },
		{ 5, Five },
		{ 6, Six },
		{ 7, Seven },
		{ 8, Eight },
		{ 9, Nine }
	};

	internal static readonly Dictionary<long, string> NumbersToWordsMapTens = new()
	{
		{ 10, Ten },
		{ 11, Eleven },
		{ 12, Twelve },
		{ 13, Thirteen },
		{ 14, Fourteen },
		{ 15, Fifteen },
		{ 16, Sixteen },
		{ 17, Seventeen },
		{ 18, Eighteen },
		{ 19, Nineteen },

		{ 20, Twenty },
		{ 30, Thirty },
		{ 40, Forty },
		{ 50, Fifty },
		{ 60, Sixty },
		{ 70, Seventy },
		{ 80, Eighty },
		{ 90, Ninety }
	};
}
