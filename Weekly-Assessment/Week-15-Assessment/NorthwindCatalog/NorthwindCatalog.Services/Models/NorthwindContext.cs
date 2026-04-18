using Microsoft.EntityFrameworkCore;

namespace NorthwindCatalog.Services.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext() { }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options) { }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Connection string comes from appsettings.json
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // -------------------------
        // Category Configuration
        // -------------------------
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName);

            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryID");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(15);

            entity.Property(e => e.Description)
                .HasColumnType("ntext");

            entity.Property(e => e.Picture)
                .HasColumnType("image");
        });

        // -------------------------
        // Product Configuration
        // -------------------------
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => e.ProductName);
            entity.HasIndex(e => e.SupplierId);

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID");

            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryID");

            entity.Property(e => e.ProductName)
                .HasMaxLength(40);

            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20);

            entity.Property(e => e.ReorderLevel)
                .HasDefaultValue((short)0);

            entity.Property(e => e.SupplierId)
                .HasColumnName("SupplierID");

            // ✅ REQUIRED: Fluent API for decimal precision
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10,2)")
                .HasDefaultValue(0m);

            entity.Property(e => e.UnitsInStock)
                .HasDefaultValue((short)0);

            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValue((short)0);

            // ✅ REQUIRED: Relationship mapping
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}