using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ada.Numbers.Converters;
using Ada.Numbers.Utilities;

namespace Ada.Numbers.Tests;

[TestClass]
public class WordsToNumberConverterTestEn
{
	private static void SimpleAssert(long expected, string actual, bool useShortScale = false)
	{
		Settings.Language = Settings.Parameters.Languages.En;
		Settings.Scale = useShortScale ? Settings.Parameters.Scales.Short : Settings.Parameters.Scales.Long;
		Assert.AreEqual(expected.ToString(), actual.ToNumber());
	}

	private static void SimpleAssert(decimal expected, string actual, bool useShortScale = false)
	{
		Settings.Language = Settings.Parameters.Languages.En;
		Settings.Scale = useShortScale ? Settings.Parameters.Scales.Short : Settings.Parameters.Scales.Long;
		Assert.AreEqual(expected.ToString(CultureInfo.InvariantCulture), actual.ToNumber());
	}

	[DataTestMethod]
	[DataRow(0, "Zero")]
	[DataRow(1, "One")]
	[DataRow(2, "Two")]
	[DataRow(3, "Three")]
	[DataRow(4, "Four")]
	[DataRow(5, "Five")]
	[DataRow(6, "Six")]
	[DataRow(7, "Seven")]
	[DataRow(8, "Eight")]
	[DataRow(9, "Nine")]
	public void UnitiesAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(10, "Ten")]
	[DataRow(11, "Eleven")]
	[DataRow(12, "Twelve")]
	[DataRow(13, "Thirteen")]
	[DataRow(14, "Fourteen")]
	[DataRow(15, "Fifteen")]
	[DataRow(16, "Sixteen")]
	[DataRow(17, "Seventeen")]
	[DataRow(18, "Eighteen")]
	[DataRow(19, "Nineteen")]
	[DataRow(20, "Twenty")]
	[DataRow(21, "Twenty-one")]
	[DataRow(30, "Thirty")]
	[DataRow(32, "Thirty-two")]
	[DataRow(40, "Forty")]
	[DataRow(43, "Forty-three")]
	[DataRow(50, "Fifty")]
	[DataRow(54, "Fifty-four")]
	[DataRow(60, "Sixty")]
	[DataRow(65, "Sixty-five")]
	[DataRow(70, "Seventy")]
	[DataRow(76, "Seventy-six")]
	[DataRow(80, "Eighty")]
	[DataRow(87, "Eighty-seven")]
	[DataRow(90, "Ninety")]
	[DataRow(98, "Ninety-eight")]
	public void TensAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow( 100, "One Hundred" )]
	[DataRow( 101, "One Hundred and One" )]
	[DataRow( 111, "One Hundred and Eleven" )]
	[DataRow( 121, "One Hundred and Twenty-one" )]
	[DataRow( 200, "Two Hundred" )]
	[DataRow( 202, "Two Hundred and Two" )]
	[DataRow( 212, "Two Hundred and Twelve" )]
	[DataRow( 222, "Two Hundred and Twenty-two" )]
	[DataRow( 300, "Three Hundred" )]
	[DataRow( 303, "Three Hundred and Three" )]
	[DataRow( 313, "Three Hundred and Thirteen" )]
	[DataRow( 333, "Three Hundred and Thirty-three" )]
	[DataRow( 400, "Four Hundred" )]
	[DataRow( 404, "Four Hundred and Four" )]
	[DataRow( 414, "Four Hundred and Fourteen" )]
	[DataRow( 444, "Four Hundred and Forty-four" )]
	[DataRow( 500, "Five Hundred" )]
	[DataRow( 505, "Five Hundred and Five" )]
	[DataRow( 515, "Five Hundred and Fifteen" )]
	[DataRow( 555, "Five Hundred and Fifty-five" )]
	[DataRow( 600, "Six Hundred" )]
	[DataRow( 606, "Six Hundred and Six" )]
	[DataRow( 616, "Six Hundred and Sixteen" )]
	[DataRow( 666, "Six Hundred and Sixty-six" )]
	[DataRow( 700, "Seven Hundred")]
	[DataRow( 707, "Seven Hundred and Seven" )]
	[DataRow( 717, "Seven Hundred and Seventeen" )]
	[DataRow( 777, "Seven Hundred and Seventy-seven" )]
	[DataRow( 800, "Eight Hundred" )]
	[DataRow( 808, "Eight Hundred and Eight" )]
	[DataRow( 818, "Eight Hundred and Eighteen" )]
	[DataRow( 888, "Eight Hundred and Eighty-eight" )]
	[DataRow( 900, "Nine Hundred" )]
	[DataRow( 909, "Nine Hundred and Nine" )]
	[DataRow( 919, "Nine Hundred and Nineteen" )]
	[DataRow( 999, "Nine Hundred and Ninety-nine" )]
	public void HundredsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000, "One Thousand")]
	[DataRow(1001, "One Thousand and One")]
	[DataRow(1011, "One Thousand and Eleven")]
	[DataRow(1111, "One Thousand, One Hundred and Eleven")]
	[DataRow(10000, "Ten Thousand")]
	[DataRow(10001, "Ten Thousand and One")]
	[DataRow(34001, "Thirty-four Thousand and One")]
	[DataRow(140000, "One Hundred, Forty Thousand")]
	[DataRow(140001, "One Hundred, Forty Thousand and One")]
	public void ThousandsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000, "One Million")]
	[DataRow(1000001, "One Million and One")]
	[DataRow(1000011, "One Million and Eleven")]
	[DataRow(1000022, "One Million and Twenty-two")]
	[DataRow(1000122, "One Million, One Hundred and Twenty-two")]
	[DataRow(2000122, "Two Million, One Hundred and Twenty-two")]
	[DataRow(20000122, "Twenty Million, One Hundred and Twenty-two")]
	[DataRow(22000122, "Twenty-two Million, One Hundred and Twenty-two")]
	public void MillionsAreValid(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000, "One Thousand Million")]
	[DataRow(1000000001, "One Thousand Million and One")]
	[DataRow(1000000011, "One Thousand Million and Eleven")]
	[DataRow(1000000022, "One Thousand Million and Twenty-two")]
	[DataRow(1000000122, "One Thousand Million, One Hundred and Twenty-two")]
	[DataRow(2000000122, "Two Thousand Million, One Hundred and Twenty-two")]
	[DataRow(20000000122, "Twenty Thousand Million, One Hundred and Twenty-two")]
	[DataRow(22000000122, "Twenty-two Thousand Million, One Hundred and Twenty-two")]
	public void ThousandMillionsAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000, "One Billion")]
	[DataRow(1000000001, "One Billion and One")]
	[DataRow(1000000011, "One Billion and Eleven")]
	[DataRow(1000000022, "One Billion and Twenty-two")]
	[DataRow(1000000122, "One Billion, One Hundred and Twenty-two")]
	[DataRow(2000000122, "Two Billion, One Hundred and Twenty-two")]
	[DataRow(20000000122, "Twenty Billion, One Hundred and Twenty-two")]
	[DataRow(22000000122, "Twenty-two Billion, One Hundred and Twenty-two")]
	public void ThousandMillionsShortScaleAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual, true);
	}

	[DataTestMethod]
	[DataRow(1000000000000, "One Billion")]
	[DataRow(1000000000001, "One Billion and One")]
	[DataRow(1000000000011, "One Billion and Eleven")]
	[DataRow(1000000000022, "One Billion and Twenty-two")]
	[DataRow(1000000000122, "One Billion, One Hundred and Twenty-two")]
	[DataRow(2000000000122, "Two Billion, One Hundred and Twenty-two")]
	[DataRow(20000000000122, "Twenty Billion, One Hundred and Twenty-two")]
	[DataRow(22000000000122, "Twenty-two Billion, One Hundred and Twenty-two")]
	public void BillionsAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(1000000000000, "One Trillion")]
	[DataRow(1000000000001, "One Trillion and One")]
	[DataRow(1000000000011, "One Trillion and Eleven")]
	[DataRow(1000000000022, "One Trillion and Twenty-two")]
	[DataRow(1000000000122, "One Trillion, One Hundred and Twenty-two")]
	[DataRow(2000000000122, "Two Trillion, One Hundred and Twenty-two")]
	[DataRow(20000000000122, "Twenty Trillion, One Hundred and Twenty-two")]
	[DataRow(22000000000122, "Twenty-two Trillion, One Hundred and Twenty-two")]
	public void BillionsShortScaleAreValid(long expected, string actual)
	{
		SimpleAssert(expected, actual, true);
	}

	[DataTestMethod]
	[DataRow(42, "Forty-two" )]
	[DataRow(102, "One Hundred and Two" )]
	[DataRow(113, "One Hundred and Thirteen" )]
	[DataRow(123, "One Hundred and Twenty-three" )]
	[DataRow(902, "Nine Hundred and Two" )]
	[DataRow(99, "Ninety-nine" )]
	[DataRow(999, "Nine Hundred and Ninety-nine" )]
	[DataRow(1000, "One Thousand" )]
	[DataRow(1123, "One Thousand, One Hundred and Twenty-three" )]
	[DataRow(30000, "Thirty Thousand" )]
	[DataRow(10123, "Ten Thousand, One Hundred and Twenty-three" )]
	[DataRow(21123, "Twenty-one Thousand, One Hundred and Twenty-three" )]
	[DataRow(100000, "One Hundred Thousand" )]
	[DataRow(100123, "One Hundred Thousand, One Hundred and Twenty-three" )]
	[DataRow(112123, "One Hundred, Twelve Thousand, One Hundred and Twenty-three" )]
	[DataRow(134123, "One Hundred, Thirty-four Thousand, One Hundred and Twenty-three" )]
	public void RandomNumbersIntegers(int expected, string actual)
	{
		SimpleAssert(expected, actual);
	}

	[DataTestMethod]
	[DataRow(42.2, "Forty-two point Two" )]
	[DataRow(102.0, "One Hundred and Two" )]
	[DataRow(103.000, "One Hundred and Three" )]
	[DataRow(113.02, "One Hundred and Thirteen point Zero Two" )]
	[DataRow(123.0045, "One Hundred and Twenty-three point Zero Zero Forty-five" )]
	[DataRow(902.982, "Nine Hundred and Two point Nine Hundred and Eighty-two" )]
	[DataRow(100000.001, "One Hundred Thousand point Zero Zero One" )]
	[DataRow(100123.100123, "One Hundred Thousand, One Hundred and Twenty-three point One Hundred Thousand, One Hundred and Twenty-three" )]
	public void RandomNumbersDecimals(double expected, string actual)
	{
		SimpleAssert((decimal)expected, actual);
	}
}
