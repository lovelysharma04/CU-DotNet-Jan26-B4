using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VagabondAPI.Models;

namespace VagabondAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<VagabondAPI.Models.Destination> Destination { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(d => d.CityName)
                      .IsRequired();

                entity.Property(d => d.Country)
                      .IsRequired();

                entity.Property(d => d.Description)
                      .HasMaxLength(200);

                entity.Property(d => d.Rating)
                      .HasDefaultValue(3);
            });
        }
    }
}
