using Day71_RazorMongo.Models;
using Day71_RazorMongo.MongoDBSetting;
using MongoDB.Driver;

public class LaptopService
{
    private readonly IMongoCollection<Laptop> _laptops;

    public LaptopService(IConfiguration config)
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
    public async Task<Laptop> GetByIdAsync(string id) =>
    await _laptops.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(string id, Laptop laptop) =>
        await _laptops.ReplaceOneAsync(x => x.Id == id, laptop);

    public async Task DeleteAsync(string id) =>
        await _laptops.DeleteOneAsync(x => x.Id == id);
}
