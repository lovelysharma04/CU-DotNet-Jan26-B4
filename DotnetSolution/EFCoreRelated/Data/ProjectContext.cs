using EFCoreRelated.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EFCoreRelated.Data
{
    internal class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=RelatedDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
            public DbSet<Dept> Departments { get; set; }
            public DbSet<Emp> Employees { get; set; }
         
    }
}
