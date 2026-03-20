using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Day62_02_LoanManagementwithDTOs.Data;

namespace Day62_02_LoanManagementwithDTOs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Day62_02_LoanManagementwithDTOsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Day62_02_LoanManagementwithDTOsContext") ?? throw new InvalidOperationException("Connection string 'Day62_02_LoanManagementwithDTOsContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
