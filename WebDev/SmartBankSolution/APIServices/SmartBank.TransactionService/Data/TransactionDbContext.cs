using Microsoft.EntityFrameworkCore;
using SmartBank.TransactionService.Models;

namespace SmartBank.TransactionService.Data
{
    public class TransactionDbContext : DbContext
    {
        // Constructor (dependency injection ke liye)
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        // Table for Transactions
        public DbSet<Transaction> Transactions { get; set; }

        // Optional: Configure decimal precision
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
