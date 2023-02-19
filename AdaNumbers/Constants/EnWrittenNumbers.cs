namespace Ada.Numbers.Constants;

internal class EnWrittenNumbers
{
	internal const string Zero = "Zero";
	internal const string One = "One";
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

	internal const string OneHundred = "One Hundred";
	internal const string Hundred = "Hundred";

	internal const string TwoHundred = "Two Hundred";
	internal const string ThreeHundred = "Three Hundred";
	internal const string FourHundred = "Four Hundred";
	internal const string FiveHundred = "Five Hundred";
	internal const string SixHundred = "Six Hundred";
	internal const string SevenHundred = "Seven Hundred";
	internal const string EightHundred = "Eight Hundred";
	internal const string NineHundred = "Nine Hundred";

	internal const string OneThousand = "One Thousand";
	internal const string Thousand = "Thousand";

	internal const string MillionSingular = "Um Milhão";
	internal const string MillionPlural = "Milhões";

	internal const string ThousandMillion = "Mil Milhões";

	internal const string BillionSingular = "Um Bilião";
	internal const string BillionPlural = "Biliões";

	internal const string TrillionSingular = "Um Trilião";
	internal const string TrillionPlural = "Triliões";

	internal static readonly List<string> NumbersThatIgnoreSeparator = new()
	{
		OneHundred,
		TwoHundred,
		ThreeHundred,
		FourHundred,
		FiveHundred,
		SixHundred,
		SevenHundred,
		EightHundred,
		NineHundred,
		Thousand,
		MillionSingular,
		MillionPlural,
		ThousandMillion,
		BillionSingular,
		BillionPlural,
		TrillionSingular,
		TrillionPlural
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
		{ OneHundred, 100 },
		{ Hundred, 100 },
		{ TwoHundred, 200 },
		{ ThreeHundred, 300 },
		{ FourHundred, 400 },
		{ FiveHundred, 500 },
		{ SixHundred, 600 },
		{ SevenHundred, 700 },
		{ EightHundred, 800 },
		{ NineHundred, 900 },
		{ OneThousand, (long)1e3 },
		{ Thousand, (long)1e3 },
		{ MillionSingular, (long)1e6 },
		{ MillionPlural, (long)1e6 }
	};

	internal static readonly Dictionary<string, long> WordsToNumberMapLongScale = new()
	{
		{ ThousandMillion, (long)1e9 },
		{ BillionSingular, (long)1e12 },
		{ BillionPlural, (long)1e12 }
	};

	internal static readonly Dictionary<string, long> WordsToNumberMapShorScale = new()
	{
		{ BillionSingular, (long)1e9 },
		{ BillionPlural, (long)1e9 },
		{ TrillionSingular, (long)1e12 },
		{ TrillionPlural, (long)1e12 }
	};

	internal static readonly List<string> NotToCombineWithThousand = new()
	{
		MillionSingular,
		BillionPlural,
		TrillionPlural
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
