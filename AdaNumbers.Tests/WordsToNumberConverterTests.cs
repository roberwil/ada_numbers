using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ada.Numbers.Converters;

namespace Ada.Numbers.Tests;

[TestClass]
public class WordsToNumberConverterTest
{
	private void SimpleAssert(long expected, string actual, bool useShortScale = false)
	{
		Assert.AreEqual(expected.ToString(), useShortScale ? actual.ToNumber(true) : actual.ToNumber());
	}

	private void SimpleAssert(decimal expected, string actual, bool useShortScale = false)
	{
		Assert.AreEqual(expected.ToString(CultureInfo.InvariantCulture), useShortScale ? actual.ToNumber(true) : actual.ToNumber());
	}

	[DataTestMethod]
	[DataRow(0, "Zero")]
	[DataRow(1, "Um")]
	[DataRow(2, "Dois")]
	[DataRow(3, "Três")]
	[DataRow(4, "Quatro")]
	[DataRow(5, "Cinco")]
	[DataRow(6, "Seis")]
	[DataRow(7, "Sete")]
	[DataRow(8, "Oito")]
	[DataRow(9, "Nove")]
	public void UnitiesAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(10, "Dez")]
	[DataRow(11, "Onze")]
	[DataRow(12, "Doze")]
	[DataRow(13, "Treze")]
	[DataRow(14, "Catorze")]
	[DataRow(15, "Quinze")]
	[DataRow(16, "Dezasseis")]
	[DataRow(17, "Dezassete")]
	[DataRow(18, "Dezoito")]
	[DataRow(19, "Dezanove")]
	[DataRow(20, "Vinte")]
	[DataRow(21, "Vinte e Um")]
	[DataRow(30, "Trinta")]
	[DataRow(32, "Trinta e Dois")]
	[DataRow(40, "Quarenta")]
	[DataRow(43, "Quarenta e Três")]
	[DataRow(50, "Cinquenta")]
	[DataRow(54, "Cinquenta e Quatro")]
	[DataRow(60, "Sessenta")]
	[DataRow(65, "Sessenta e Cinco")]
	[DataRow(70, "Setenta")]
	[DataRow(76, "Setenta e Seis")]
	[DataRow(80, "Oitenta")]
	[DataRow(87, "Oitenta e Sete")]
	[DataRow(90, "Noventa")]
	[DataRow(98, "Noventa e Oito")]
	public void TensAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow( 100, "Cem" )]
	[DataRow( 101, "Cento e Um" )]
	[DataRow( 111, "Cento e Onze" )]
	[DataRow( 121, "Cento e Vinte e Um" )]
	[DataRow( 200, "Duzentos" )]
	[DataRow( 202, "Duzentos e Dois" )]
	[DataRow( 212, "Duzentos e Doze" )]
	[DataRow( 222, "Duzentos e Vinte e Dois" )]
	[DataRow( 300, "Trezentos" )]
	[DataRow( 303, "Trezentos e Três" )]
	[DataRow( 313, "Trezentos e Treze" )]
	[DataRow( 333, "Trezentos e Trinta e Três" )]
	[DataRow( 400, "Quatrocentos" )]
	[DataRow( 404, "Quatrocentos e Quatro" )]
	[DataRow( 414, "Quatrocentos e Catorze" )]
	[DataRow( 444, "Quatrocentos e Quarenta e Quatro" )]
	[DataRow( 500, "Quinhentos" )]
	[DataRow( 505, "Quinhentos e Cinco" )]
	[DataRow( 515, "Quinhentos e Quinze" )]
	[DataRow( 555, "Quinhentos e Cinquenta e Cinco" )]
	[DataRow( 600, "Seiscentos" )]
	[DataRow( 606, "Seiscentos e Seis" )]
	[DataRow( 616, "Seiscentos e Dezasseis" )]
	[DataRow( 666, "Seiscentos e Sessenta e Seis" )]
	[DataRow( 700, "Setecentos" )]
	[DataRow( 707, "Setecentos e Sete" )]
	[DataRow( 717, "Setecentos e Dezassete" )]
	[DataRow( 777, "Setecentos e Setenta e Sete" )]
	[DataRow( 800, "Oitocentos" )]
	[DataRow( 808, "Oitocentos e Oito" )]
	[DataRow( 818, "Oitocentos e Dezoito" )]
	[DataRow( 888, "Oitocentos e Oitenta e Oito" )]
	[DataRow( 900, "Novecentos" )]
	[DataRow( 909, "Novecentos e Nove" )]
	[DataRow( 919, "Novecentos e Dezanove" )]
	[DataRow( 999, "Novecentos e Noventa e Nove" )]
	public void HundredsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000, "Mil")]
	[DataRow(1001, "Mil e Um")]
	[DataRow(1011, "Mil e Onze")]
	[DataRow(1111, "Mil Cento e Onze")]
	[DataRow(10000, "Dez Mil")]
	[DataRow(10001, "Dez Mil e Um")]
	[DataRow(34001, "Trinta e Quatro Mil e Um")]
	[DataRow(140000, "Cento e Quarenta Mil")]
	[DataRow(140001, "Cento e Quarenta Mil e Um")]
	public void ThousandsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000, "Um Milhão")]
	[DataRow(1000001, "Um Milhão e Um")]
	[DataRow(1000011, "Um Milhão e Onze")]
	[DataRow(1000022, "Um Milhão e Vinte e Dois")]
	[DataRow(1000122, "Um Milhão Cento e Vinte e Dois")]
	[DataRow(2000122, "Dois Milhões Cento e Vinte e Dois")]
	[DataRow(20000122, "Vinte Milhões Cento e Vinte e Dois")]
	[DataRow(22000122, "Vinte e Dois Milhões Cento e Vinte e Dois")]
	public void MillionsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000, "Mil Milhões")]
	[DataRow(1000000001, "Mil Milhões e Um")]
	[DataRow(1000000011, "Mil Milhões e Onze")]
	[DataRow(1000000022, "Mil Milhões e Vinte e Dois")]
	[DataRow(1000000122, "Mil Milhões Cento e Vinte e Dois")]
	[DataRow(2000000122, "Dois Mil Milhões Cento e Vinte e Dois")]
	[DataRow(20000000122, "Vinte Mil Milhões Cento e Vinte e Dois")]
	[DataRow(22000000122, "Vinte e Dois Mil Milhões Cento e Vinte e Dois")]

	public void ThousandMillionsAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000, "Um Bilião")]
	[DataRow(1000000001, "Um Bilião e Um")]
	[DataRow(1000000011, "Um Bilião e Onze")]
	[DataRow(1000000022, "Um Bilião e Vinte e Dois")]
	[DataRow(1000000122, "Um Bilião Cento e Vinte e Dois")]
	[DataRow(2000000122, "Dois Biliões Cento e Vinte e Dois")]
	[DataRow(20000000122, "Vinte Biliões Cento e Vinte e Dois")]
	[DataRow(22000000122, "Vinte e Dois Biliões Cento e Vinte e Dois")]
	public void ThousandMillionsShortScaleAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual, true);
	}

	[DataTestMethod]
	[DataRow(1000000000000, "Um Bilião")]
	[DataRow(1000000000001, "Um Bilião e Um")]
	[DataRow(1000000000011, "Um Bilião e Onze")]
	[DataRow(1000000000022, "Um Bilião e Vinte e Dois")]
	[DataRow(1000000000122, "Um Bilião Cento e Vinte e Dois")]
	[DataRow(2000000000122, "Dois Biliões Cento e Vinte e Dois")]
	[DataRow(20000000000122, "Vinte Biliões Cento e Vinte e Dois")]
	[DataRow(22000000000122, "Vinte e Dois Biliões Cento e Vinte e Dois")]

	public void BillionsAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000000, "Um Trilião")]
	[DataRow(1000000000001, "Um Trilião e Um")]
	[DataRow(1000000000011, "Um Trilião e Onze")]
	[DataRow(1000000000022, "Um Trilião e Vinte e Dois")]
	[DataRow(1000000000122, "Um Trilião Cento e Vinte e Dois")]
	[DataRow(2000000000122, "Dois Triliões Cento e Vinte e Dois")]
	[DataRow(20000000000122, "Vinte Triliões Cento e Vinte e Dois")]
	[DataRow(22000000000122, "Vinte e Dois Triliões Cento e Vinte e Dois")]

	public void BillionsShortScaleAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual, true);
	}

	[DataTestMethod]
	[DataRow(42, "Quarenta e Dois" )]
	[DataRow(102, "Cento e Dois" )]
	[DataRow(113, "Cento e Treze" )]
	[DataRow(123, "Cento e Vinte e Três" )]
	[DataRow(902, "Novecentos e Dois" )]
	[DataRow(99, "Noventa e Nove" )]
	[DataRow(999, "Novecentos e Noventa e Nove" )]
	[DataRow(1000, "Mil" )]
	[DataRow(1123, "Mil Cento e Vinte e Três" )]
	[DataRow(30000, "Trinta Mil" )]
	[DataRow(10123, "Dez Mil Cento e Vinte e Três" )]
	[DataRow(21123, "Vinte e Um Mil Cento e Vinte e Três" )]
	[DataRow(100000, "Cem Mil" )]
	[DataRow(100123, "Cem Mil Cento e Vinte e Três" )]
	[DataRow(112123, "Cento e Doze Mil Cento e Vinte e Três" )]
	[DataRow(134123, "Cento e Trinta e Quatro Mil Cento e Vinte e Três" )]
	public void RandomNumbersIntegers(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[Ignore]
	[DataTestMethod]
	[DataRow(42.2, "Quarenta e Dois Vírgula Dois" )]
	[DataRow(102.0, "Cento e Dois" )]
	[DataRow(103.000, "Cento e Três" )]
	[DataRow(113.02, "Cento e Treze Vírgula Zero Dois" )]
	[DataRow(123.0045, "Cento e Vinte e Três Vírgula Zero Zero Quarenta e Cinco" )]
	[DataRow(902.982, "Novecentos e Dois Vírgula Novecentos e Oitenta e Dois" )]
	[DataRow(100000.001, "Cem Mil Vírgula Zero Zero Um" )]
	[DataRow(100123.100123, "Cem Mil Cento e Vinte e Três Vírgula Cem Mil Cento e Vinte e Três" )]
	public void RandomNumbersDecimals(decimal expected, string actual)
	{
		SimpleAssert(expected, actual);
	}
}
