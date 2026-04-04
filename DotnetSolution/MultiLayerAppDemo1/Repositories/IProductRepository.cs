using MultiLayerAppDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerAppDemo1.Repositories
{
    internal interface IProductRepository
    {
        void AddProduct(Product product);
        public IEnumerable<Product> GetProducts();

    }
}
