using Day71_RazorMongo.Models;
using Day71_RazorMongo.MongoDBSetting;
using Day71_RazorMongo.Repository;
using MongoDB.Driver;

public class LaptopRepository : ILaptopRepository
{
    private readonly IMongoCollection<Laptop> _laptops;

    public LaptopRepository(IConfiguration config)
    {
        var settings = config.GetSection("DatabaseSettings").Get<DatabaseSettings>();

        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _laptops = database.GetCollection<Laptop>(settings.CollectionName);
    }

    public async Task<List<Laptop>> GetAsync()
    {
        return await _laptops.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(Laptop laptop)
    {
        await _laptops.InsertOneAsync(laptop);
    }
}