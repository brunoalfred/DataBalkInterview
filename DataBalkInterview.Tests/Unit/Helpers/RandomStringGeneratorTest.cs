using System;

using DataBalkInterview.Helpers;

namespace DataBalkInterview.Tests.Unit.Helpers
{
	[TestClass]
	public class RandomStringGeneratorTest
	{
		[TestMethod]
		public void TestRandomStringGenerator()
		{
			// Arrange


			// Act
			var randomString = RandomStringGenerator.GenerateRandomString(10);

			// Assert
			Assert.IsTrue(randomString.Length == 10);
		}
	}
}

