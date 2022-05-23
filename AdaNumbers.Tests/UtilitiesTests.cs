
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ada.Numbers.Utilities;

namespace Ada.Numbers.Tests;

[TestClass]
public class UtilitiesTests
{
	[TestMethod]
	public void CategorizeNumbersTest()
	{
		var numbers = new Dictionary<long, NumberCategory>()
		{
			{1, NumberCategory.Unity},
			{11, NumberCategory.Ten},
			{111, NumberCategory.Hundred},

			{1111, NumberCategory.Thousand},
			{11111, NumberCategory.Thousand},
			{111111, NumberCategory.Thousand},

			{1111111, NumberCategory.Million},
			{11111111, NumberCategory.Million},
			{111111111, NumberCategory.Million},

			{1111111111, NumberCategory.ThousandMiliions},
			{11111111111, NumberCategory.ThousandMiliions},
			{111111111111, NumberCategory.ThousandMiliions},

			{1111111111111, NumberCategory.Billion},
			{11111111111111, NumberCategory.Billion},
			{111111111111111, NumberCategory.Billion}
		};

		foreach (var (number, category) in numbers)
		{
			Assert.AreEqual(category, number.Category());
		}

	}
}
