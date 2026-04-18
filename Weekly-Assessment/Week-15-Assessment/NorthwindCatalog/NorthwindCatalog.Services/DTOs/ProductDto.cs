namespace NorthwindCatalog.Services.DTOs
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

        // Calculated field — NOT mapped by AutoMapper, computed from properties
        public decimal InventoryValue => UnitPrice * UnitsInStock;
    }
}
