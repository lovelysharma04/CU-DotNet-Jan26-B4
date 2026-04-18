
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NorthwindCatalog.Services.Mapping;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.Repositories;

namespace NorthwindCatalog.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Controllers + Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ EF Core DB Context
            builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ✅ AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // ✅ Repository registrations
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // ✅ Swagger (dev only)
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