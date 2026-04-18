using NorthwindCatalog.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Test Product",
                UnitPrice = 25.50m,
                UnitsInStock = 10
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(255.00m, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_NoStock()
        {
            var product = new ProductDto
            {
                UnitPrice = 100m,
                UnitsInStock = 0
            };

            Assert.Equal(0m, product.InventoryValue);
        }
    }
}
