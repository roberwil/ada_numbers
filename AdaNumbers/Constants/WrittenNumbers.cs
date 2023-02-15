namespace Ada.Numbers.Constants;

public static class WrittenNumbers
{
	public const string Zero = "Zero";
	public const string One = "Um";
	public const string Two = "Dois";
	public const string Three = "Três";
	public const string Four = "Quatro";
	public const string Five = "Cinco";
	public const string Six = "Seis";
	public const string Seven = "Sete";
	public const string Eight = "Oito";
	public const string Nine = "Nove";

	public const string Ten = "Dez";
	public const string Eleven = "Onze";
	public const string Twelve = "Doze";
	public const string Thirteen = "Treze";
	public const string Fourteen = "Catorze";
	public const string Fifteen = "Quinze";
	public const string Sixteen = "Dezasseis";
	public const string Seventeen = "Dezassete";
	public const string Eighteen = "Dezoito";
	public const string Nineteen = "Dezanove";

	public const string Twenty = "Vinte";
	public const string Thirty = "Trinta";
	public const string Forty = "Quarenta";
	public const string Fifty = "Cinquenta";
	public const string Sixty = "Sessenta";
	public const string Seventy = "Setenta";
	public const string Eighty = "Oitenta";
	public const string Ninety = "Noventa";

	public const string OneHundredSingle = "Cem";
	public const string OneHundred = "Cento";

	public const string TwoHundred = "Duzentos";
	public const string ThreeHundred = "Trezentos";
	public const string FourHundred = "Quatrocentos";
	public const string FiveHundred = "Quinhentos";
	public const string SixHundred = "Seiscentos";
	public const string SevenHundred = "Setecentos";
	public const string EightHundred = "Oitocentos";
	public const string NineHundred = "Novecentos";

	public const string Thousand = "Mil";

	public const string MillionSingular = "Um Milhão";
	public const string MillionPlural = "Milhões";

	public const string ThousandMillion = "Mil Milhões";

	public const string BillionSingular = "Um Bilião";
	public const string BillionPlural = "Biliões";

	public const string TrillionSingular = "Um Trilião";
	public const string TrillionPlural = "Triliões";

	public static readonly List<string> NumbersThatIgnoreSeparator = new()
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

	public static readonly Dictionary<string, long> WordsToNumberMap = new()
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

	public static readonly Dictionary<string, long> WordsToNumberMapLongScale = new()
	{
		{ ThousandMillion, (long)1e9 },
		{ BillionSingular, (long)1e12 },
		{ BillionPlural, (long)1e12 }
	};

	public static readonly Dictionary<string, long> WordsToNumberMapShorScale = new()
	{
		{ BillionSingular, (long)1e9 },
		{ BillionPlural, (long)1e9 },
		{ TrillionSingular, (long)1e12 },
		{ TrillionPlural, (long)1e12 }
	};

	public static readonly List<string> NotToCombineWithThousand = new()
	{
		MillionSingular,
		BillionPlural,
		TrillionPlural
	};

	public static readonly Dictionary<long, string> NumbersToWordsMapUnities = new()
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

	public static readonly Dictionary<long, string> NumbersToWordsMapTens = new()
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
