
using Microsoft.EntityFrameworkCore;
using WebAPIdbFirst.Data;
using Serilog;

namespace WebAPIdbFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<MyAppDbContext>(options =>
                options.UseSqlServer(connectionString));


            // 1. Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Log Info, Warning, and Error
                .WriteTo.Console()          // Also show logs in the debug console
                .WriteTo.File("logs/myapp-.txt", rollingInterval: RollingInterval.Day) // Save to file
                .CreateLogger();

            builder.Host.UseSerilog(); //2.  Use Serilog as the logging provider

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.UseSerilogRequestLogging(); // 3. Log HTTP requests

            app.MapControllers();

            app.Run();
        }
    }
}
