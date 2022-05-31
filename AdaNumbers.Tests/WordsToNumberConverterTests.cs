using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ada.Numbers.Converters;

namespace Ada.Numbers.Tests;

[TestClass]
public class WordsToNumberConverterTest
{
	[TestMethod]
	public void UnitiesAreValid()
	{
		var numbers = new Dictionary<int, string>()
		{
			{ 0, "Zero" },
			{ 1, "Um" },
			{ 2, "Dois" },
			{ 3, "Três" },
			{ 4, "Quatro" },
			{ 5, "Cinco" },
			{ 6, "Seis" },
			{ 7, "Sete" },
			{ 8, "Oito" },
			{ 9, "Nove" }
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	public void TensAreValid()
	{
		var numbers = new Dictionary<int, string>()
		{
			{ 10, "Dez" },
			{ 11, "Onze" },
			{ 12, "Doze" },
			{ 13, "Treze" },
			{ 14, "Catorze" },
			{ 15, "Quinze" },
			{ 16, "Dezasseis" },
			{ 17, "Dezassete" },
			{ 18, "Dezoito" },
			{ 19, "Dezanove" },

			{ 20, "Vinte" },
			{ 21, "Vinte e Um" },

			{ 30, "Trinta" },
			{ 32, "Trinta e Dois" },

			{ 40, "Quarenta" },
			{ 43, "Quarenta e Três" },

			{ 50, "Cinquenta" },
			{ 54, "Cinquenta e Quatro" },

			{ 60, "Sessenta" },
			{ 65, "Sessenta e Cinco" },

			{ 70, "Setenta" },
			{ 76, "Setenta e Seis" },

			{ 80, "Oitenta" },
			{ 87, "Oitenta e Sete" },

			{ 90, "Noventa" },
			{ 98, "Noventa e Oito" },
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), description.ToNumber());
		}
	}

	[TestMethod]
	public void HundredsAreValid()
	{
		var numbers = new Dictionary<int, string>()
		{
			{ 100, "Cem" },
			{ 101, "Cento e Um" },
			{ 111, "Cento e Onze" },
			{ 121, "Cento e Vinte e Um" },

			{ 200, "Duzentos" },
			{ 202, "Duzentos e Dois" },
			{ 212, "Duzentos e Doze" },
			{ 222, "Duzentos e Vinte e Dois" },

			{ 300, "Trezentos" },
			{ 303, "Trezentos e Três" },
			{ 313, "Trezentos e Treze" },
			{ 333, "Trezentos e Trinta e Três" },

			{ 400, "Quatrocentos" },
			{ 404, "Quatrocentos e Quatro" },
			{ 414, "Quatrocentos e Catorze" },
			{ 444, "Quatrocentos e Quarenta e Quatro" },

			{ 500, "Quinhentos" },
			{ 505, "Quinhentos e Cinco" },
			{ 515, "Quinhentos e Quinze" },
			{ 555, "Quinhentos e Cinquenta e Cinco" },

			{ 600, "Seiscentos" },
			{ 606, "Seiscentos e Seis" },
			{ 616, "Seiscentos e Dezasseis" },
			{ 666, "Seiscentos e Sessenta e Seis" },

			{ 700, "Setecentos" },
			{ 707, "Setecentos e Sete" },
			{ 717, "Setecentos e Dezassete" },
			{ 777, "Setecentos e Setenta e Sete" },

			{ 800, "Oitocentos" },
			{ 808, "Oitocentos e Oito" },
			{ 818, "Oitocentos e Dezoito" },
			{ 888, "Oitocentos e Oitenta e Oito" },

			{ 900, "Novecentos" },
			{ 909, "Novecentos e Nove" },
			{ 919, "Novecentos e Dezanove" },
			{ 999, "Novecentos e Noventa e Nove" }
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	public void ThousandsAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000, "Mil"},
			{1001, "Mil e Um"},
			{1011, "Mil e Onze"},
			{1111, "Mil Cento e Onze"},

			{10000, "Dez Mil"},
			{10001, "Dez Mil e Um"},
			{34001, "Trinta e Quatro Mil e Um"},

			{140000, "Cento e Quarenta Mil"},
			{140001, "Cento e Quarenta Mil e Um"}
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	public void MillionsAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000000, "Um Milhão"},
			{1000001, "Um Milhão e Um"},
			{1000011, "Um Milhão e Onze"},
			{1000022, "Um Milhão e Vinte e Dois"},
			{1000122, "Um Milhão Cento e Vinte e Dois"},
			{2000122, "Dois Milhões Cento e Vinte e Dois"},

			{20000122, "Vinte Milhões Cento e Vinte e Dois"},
			{22000122, "Vinte e Dois Milhões Cento e Vinte e Dois"},
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	public void ThousandMillionsAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000000000, "Mil Milhões"},
			{1000000001, "Mil Milhões e Um"},
			{1000000011, "Mil Milhões e Onze"},
			{1000000022, "Mil Milhões e Vinte e Dois"},
			{1000000122, "Mil Milhões Cento e Vinte e Dois"},
			{2000000122, "Dois Mil Milhões Cento e Vinte e Dois"},

			{20000000122, "Vinte Mil Milhões Cento e Vinte e Dois"},
			{22000000122, "Vinte e Dois Mil Milhões Cento e Vinte e Dois"},
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	public void ThousandMillionsShortScaleAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000000000, "Um Bilião"},
			{1000000001, "Um Bilião e Um"},
			{1000000011, "Um Bilião e Onze"},
			{1000000022, "Um Bilião e Vinte e Dois"},
			{1000000122, "Um Bilião Cento e Vinte e Dois"},
			{2000000122, "Dois Biliões Cento e Vinte e Dois"},

			{20000000122, "Vinte Biliões Cento e Vinte e Dois"},
			{22000000122, "Vinte e Dois Biliões Cento e Vinte e Dois"},
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), description.ToNumber(true));
		}
	}

	[TestMethod]
	public void BillionsAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000000000000, "Um Bilião"},
			{1000000000001, "Um Bilião e Um"},
			{1000000000011, "Um Bilião e Onze"},
			{1000000000022, "Um Bilião e Vinte e Dois"},
			{1000000000122, "Um Bilião Cento e Vinte e Dois"},
			{2000000000122, "Dois Biliões Cento e Vinte e Dois"},

			{20000000000122, "Vinte Biliões Cento e Vinte e Dois"},
			{22000000000122, "Vinte e Dois Biliões Cento e Vinte e Dois"},
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), description.ToNumber());
		}
	}

	[TestMethod]
	public void BillionsShortScaleAreValid()
	{
		var numbers = new Dictionary<long, string>()
		{
			{1000000000000, "Um Trilião"},
			{1000000000001, "Um Trilião e Um"},
			{1000000000011, "Um Trilião e Onze"},
			{1000000000022, "Um Trilião e Vinte e Dois"},
			{1000000000122, "Um Trilião Cento e Vinte e Dois"},
			{2000000000122, "Dois Triliões Cento e Vinte e Dois"},

			{20000000000122, "Vinte Triliões Cento e Vinte e Dois"},
			{22000000000122, "Vinte e Dois Triliões Cento e Vinte e Dois"},
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description, true)!);
		}
	}

	[TestMethod]
	public void RandomNumbersIntegers()
	{
		var numbers = new Dictionary<int, string>()
		{
			{ 42, "Quarenta e Dois" },
			{ 102, "Cento e Dois" },
			{ 113, "Cento e Treze" },
			{ 123, "Cento e Vinte e Três" },
			{ 902, "Novecentos e Dois" },
			{ 99, "Noventa e Nove" },
			{ 999, "Novecentos e Noventa e Nove" },
			{ 1000, "Mil" },
			{ 1123, "Mil Cento e Vinte e Três" },
			{ 30000, "Trinta Mil" },
			{ 10123, "Dez Mil Cento e Vinte e Três" },
			{ 21123, "Vinte e Um Mil Cento e Vinte e Três" },
			{ 100000, "Cem Mil" },
			{ 100123, "Cem Mil Cento e Vinte e Três" },
			{ 112123, "Cento e Doze Mil Cento e Vinte e Três" },
			{ 134123, "Cento e Trinta e Quatro Mil Cento e Vinte e Três" }
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(number.ToString(), WordsToNumberConverter.Convert(description)!);
		}
	}

	[TestMethod]
	[Ignore]
	public void RandomNumbersDecimals()
	{
		var numbers = new Dictionary<decimal, string>()
		{
			{ 42.2m, "Quarenta e Dois Vírgula Dois" },
			{ 102.0m, "Cento e Dois" },
			{ 103.000m, "Cento e Três" },
			{ 113.02m, "Cento e Treze Vírgula Zero Dois" },
			{ 123.0045m, "Cento e Vinte e Três Vírgula Zero Zero Quarenta e Cinco" },
			{ 902.982m, "Novecentos e Dois Vírgula Novecentos e Oitenta e Dois" },
			{ 100000.001m, "Cem Mil Vírgula Zero Zero Um" },
			{ 100123.100123m, "Cem Mil Cento e Vinte e Três Vírgula Cem Mil Cento e Vinte e Três" }
		};

		foreach (var (number, description) in numbers)
		{
			Assert.AreEqual(description, number.ToWords());
		}
	}
}
