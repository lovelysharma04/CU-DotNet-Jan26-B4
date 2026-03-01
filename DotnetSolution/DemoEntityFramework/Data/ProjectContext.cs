using DemoEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework.Data
{
    internal class ProjectContext:DbContext
    {
        public DbSet<Laptop> laptops { get ; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=MyLaptopsDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
