using _BankWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _BankWebAPI.Middleware
{
    public class ApiKeyValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string validApiKey = "bank-api";

        public ApiKeyValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext database)
        {
            string? apiKey = httpContext.Request.Headers["X-API-Key"];

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("Authentication failed: API key is missing or invalid");
                return;
            }

            await _next(httpContext);
        }
    }

    public static class ApiKeyValidationExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ApiKeyValidationMiddleware>();
            return builder;
        }
    }
}