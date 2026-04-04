using MultiLayerAppDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerAppDemo1.Repositories
{
    internal class FileProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
