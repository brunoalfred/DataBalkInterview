using System;
using DataBalkInterview.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBalkInterview.Middleware
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string APIKEY = "X-Api-Key";

		private readonly IServiceScopeFactory _serviceScopeFactory;

		public ApiKeyMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
		{
			_next = next;
			_serviceScopeFactory = serviceScopeFactory;
		}


		public async Task InvokeAsync(HttpContext context)
		{
			// Check if the request path matches our path
			if (context.Request.Path.StartsWithSegments("/api"))
			{
				// Check if the request contains our API key header
				if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
				{
					// Stop further pipeline processing
					context.Response.StatusCode = 401;
					await context.Response.WriteAsync("API Key was not provided. (Unauthorized)");
					return;
				}

				//TODO: Validate the API key
				using (var scope = _serviceScopeFactory.CreateScope())
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
					// print the connection string to prove it did inject it
					Console.WriteLine(dbContext.Database.GetConnectionString());

					var apiKeyValue = extractedApiKey.FirstOrDefault();

					var apiKey = dbContext.Users.FirstOrDefault(x => x.ApiKey == apiKeyValue);

					if (apiKey == null)
					{
						// Stop further pipeline processing
						context.Response.StatusCode = 401;
						await context.Response.WriteAsync("Unauthorized API Key. (Unauthorized)");
						return;
					}
				}

			}

			// Call the next delegate/middleware in the pipeline.
			await _next(context);
		}
	}
}


