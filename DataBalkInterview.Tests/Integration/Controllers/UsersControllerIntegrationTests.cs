using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
namespace DataBalkInterview.Tests.Integration.Controllers
{
	[TestClass]
	public class UsersControllerIntegrationTests
	{
		private HttpClient _client;


		[TestInitialize]
		public void TestInitialize()
		{
			// Set up the HttpClient and other necessary configurations
			_client = new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7128/")
			};
			_client.DefaultRequestHeaders.Add("X-Api-Key", "UlltQMBKl4U0NJRRNQ8F7CxmjS2gCqSj5fMrvwIBHKvqce9l0ZpldOywBQ32taicUL2y6PS4AScVRCex4zQ7PQWcQ2J5VQ9OVQsQSGo30lQyEsDDhjAdqYRcnDVm3lucJQEwUpzvTCe1JXEKGfLoDVJmxehQO3uf00dBWxiayxnpODZqLVAb1FpqehvSMlRlXYx6hPYs");

		}


		[TestMethod]
		public async Task Get_All_Users_Success()
		{
			// Act

			var response = await _client.GetAsync("/api/User");

			// Assert
			response.EnsureSuccessStatusCode(); // Check if the response status code is success (2xx)
			var content = await response.Content.ReadAsStringAsync();

			Assert.IsTrue(content.Length > 0);
		}

		// TODO: More tests

	}
}

