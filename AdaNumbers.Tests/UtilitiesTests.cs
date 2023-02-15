using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ada.Numbers.Utilities;

namespace Ada.Numbers.Tests;

[TestClass]
public class UtilitiesTests
{
	[DataTestMethod]
	[DataRow(1, NumberCategory.Unity)]
	[DataRow(11, NumberCategory.Ten)]
	[DataRow(111, NumberCategory.Hundred)]
	[DataRow(1111, NumberCategory.Thousand)]
	[DataRow(11111, NumberCategory.Thousand)]
	[DataRow(111111, NumberCategory.Thousand)]
	[DataRow(1111111, NumberCategory.Million)]
	[DataRow(11111111, NumberCategory.Million)]
	[DataRow(111111111, NumberCategory.Million)]
	[DataRow(1111111111, NumberCategory.ThousandMillions)]
	[DataRow(11111111111, NumberCategory.ThousandMillions)]
	[DataRow(111111111111, NumberCategory.ThousandMillions)]
	[DataRow(1111111111111, NumberCategory.Billion)]
	[DataRow(11111111111111, NumberCategory.Billion)]
	[DataRow(111111111111111, NumberCategory.Billion)]
	public void MustHaveRightCategory(long actual, NumberCategory expected)
	{
		Assert.AreEqual(expected, actual.Category());
	}

	[DataTestMethod]
	[DataRow(1, 1)]
	[DataRow(12, 1)]
	[DataRow(123, 1)]
	[DataRow(1234, 1)]
	[DataRow(12345, 2)]
	[DataRow(123456, 3)]
	[DataRow(1234567, 1)]
	[DataRow(12345678, 2)]
	[DataRow(123456789, 3)]
	[DataRow(1234567890, 1)]
	[DataRow(12345678901, 2)]
	[DataRow(123456789012, 3)]
	[DataRow(1234567890123, 1)]
	[DataRow(12345678901234, 2)]
	[DataRow(123456789012345, 3)]
	public void MustHaveRightBridge(long actual, int expected)
	{
		Assert.AreEqual(expected, actual.Bridge());
	}
}
