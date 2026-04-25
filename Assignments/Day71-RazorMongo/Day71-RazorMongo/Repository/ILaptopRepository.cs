using Day71_RazorMongo.Models;

namespace Day71_RazorMongo.Repository
{
    public interface ILaptopRepository
    {
        Task<List<Laptop>> GetAsync();
        Task CreateAsync(Laptop laptop);
    }
}
