using MultiLayerAppDemo1.Models;
using MultiLayerAppDemo1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerAppDemo1.Services
{
    internal class ProductServices : IProductServices
    {
        //IProductRepository repository=new ProductRepository();
        private IProductRepository _repository { get; set; }
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentException("Product name cannot be null or empty.");
            }
            if (product.Price <= 0 || product.Price>100000)
            {
                throw new ArgumentException("Product price range should be 1 - 100000");
            }
            _repository.AddProduct(product);
        }
        public IEnumerable<Product> GetProducts()
        {
           return _repository.GetProducts();
        }
    }
}
