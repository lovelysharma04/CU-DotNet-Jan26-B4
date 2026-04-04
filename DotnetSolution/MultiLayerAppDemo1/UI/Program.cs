using MultiLayerAppDemo1.Models;
using MultiLayerAppDemo1.Repositories;
using MultiLayerAppDemo1.Services;

namespace MultiLayerAppDemo1.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("File or List(1/2)");
            var repoType = int.Parse(Console.ReadLine());

            var product = GetProduct();
            IProductRepository repository = null ;

            if (repoType == 1)
            {
                Console.WriteLine("Using File Repository");
                repository = new FileProductRepository();
              
            }
            else if(repoType == 2)
            {
                Console.WriteLine("Using List Repository");
                repository = new ProductRepository();
                
            }
            IProductServices services = new ProductServices(repository);
            try
            {
                services.AddProduct(product);
                IEnumerable<Product> products= services.GetProducts();
                DisplayProducts(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static Product GetProduct()
        {
            Product product = new Product()
            {
                ProductId = 1,
                Name = "Laptop",
                Price = 35000
            };
            return product;
        }
        static void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, Name: {product.Name}, Price: {product.Price}");
            }
        }

    }
}
