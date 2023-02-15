namespace Ada.Numbers.Constants;

internal static class WrittenNumbers
{
	internal const string Zero = "Zero";
	internal const string One = "Um";
	private const string Two = "Dois";
	private const string Three = "Três";
	private const string Four = "Quatro";
	private const string Five = "Cinco";
	private const string Six = "Seis";
	private const string Seven = "Sete";
	private const string Eight = "Oito";
	private const string Nine = "Nove";

	private const string Ten = "Dez";
	private const string Eleven = "Onze";
	private const string Twelve = "Doze";
	private const string Thirteen = "Treze";
	private const string Fourteen = "Catorze";
	private const string Fifteen = "Quinze";
	private const string Sixteen = "Dezasseis";
	private const string Seventeen = "Dezassete";
	private const string Eighteen = "Dezoito";
	private const string Nineteen = "Dezanove";

	private const string Twenty = "Vinte";
	private const string Thirty = "Trinta";
	private const string Forty = "Quarenta";
	private const string Fifty = "Cinquenta";
	private const string Sixty = "Sessenta";
	private const string Seventy = "Setenta";
	private const string Eighty = "Oitenta";
	private const string Ninety = "Noventa";

	internal const string OneHundredSingle = "Cem";
	internal const string OneHundred = "Cento";

	internal const string TwoHundred = "Duzentos";
	internal const string ThreeHundred = "Trezentos";
	internal const string FourHundred = "Quatrocentos";
	internal const string FiveHundred = "Quinhentos";
	internal const string SixHundred = "Seiscentos";
	internal const string SevenHundred = "Setecentos";
	internal const string EightHundred = "Oitocentos";
	internal const string NineHundred = "Novecentos";

	internal const string Thousand = "Mil";

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
		{ OneHundredSingle, 100 },
		{ TwoHundred, 200 },
		{ ThreeHundred, 300 },
		{ FourHundred, 400 },
		{ FiveHundred, 500 },
		{ SixHundred, 600 },
		{ SevenHundred, 700 },
		{ EightHundred, 800 },
		{ NineHundred, 900 },
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
