using _BankWebAPI.Data;
using _BankWebAPI.Middleware;
using _BankWebAPI.Services;
using _BankWebAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace _BankWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IClientService, ClientService>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("Default");

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new MissingFieldException("Failed to get Default connection string");

                options.UseSqlServer(connectionString);
            });

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception exception)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    Console.WriteLine($"�������� ������! {exception.Message}");
                }
            });

            app.UseLogging();
            app.UseApiKeyValidation();

            app.MapControllers();

            app.Run();
        }
    }
}
