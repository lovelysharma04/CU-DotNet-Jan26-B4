using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebFluentAPIDemo.Models;

namespace WebFluentAPIDemo.Data
{
    public class WebFluentAPIDemoContext : DbContext
    {
        public WebFluentAPIDemoContext (DbContextOptions<WebFluentAPIDemoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Year).IsRequired();
            });
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2020,
                    Color = "Red",
                    Price = 20000m,
                    FuelType = "Petrol",
                    Mileage = 15000,
                    Transmission = "Automatic",
                    SeatingCapacity = 5,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Car
                {
                    Id = 2,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2019,
                    Color = "Blue",
                    Price = 22000m,
                    FuelType = "Petrol",
                    Mileage = 20000,
                    Transmission = "Manual",
                    SeatingCapacity = 5,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
            modelBuilder.Entity<Car>()
                        .Property(p=>p.Id)
                        .ValueGeneratedNever();
        }
        public DbSet<WebFluentAPIDemo.Models.Car> Car { get; set; } = default!;
    }
}
