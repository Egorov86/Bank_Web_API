using System.Diagnostics;
using System.Net;

namespace _BankWebAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            IPAddress? remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            string method = httpContext.Request.Method;
            PathString path = httpContext.Request.Path;

            _logger.LogInformation($"{remoteIpAddress}: {method} {path}");

            Stopwatch stopwatch = Stopwatch.StartNew();

            await _next(httpContext);

            stopwatch.Stop();

            _logger.LogInformation($"Response time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public static class LoggingExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LoggingMiddleware>();
            return builder;
        }
    }
}
