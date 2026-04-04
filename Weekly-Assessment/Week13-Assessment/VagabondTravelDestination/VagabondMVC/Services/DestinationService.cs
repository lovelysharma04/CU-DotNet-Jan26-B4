using System.Net.Http.Json;
using VagabondMVC.Models;
using VagabondMVC.Services;

public class DestinationService : IDestinationService
{
    private readonly HttpClient _httpClient;

    public DestinationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Destination>>("api/destinations");
    }

    public async Task<Destination> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Destination>($"api/destinations/{id}");
    }

    public async Task CreateAsync(Destination destination)
    {
        await _httpClient.PostAsJsonAsync("api/destinations", destination);
    }

    public async Task UpdateAsync(Destination destination)
    {
        await _httpClient.PutAsJsonAsync($"api/destinations/{destination.Id}", destination);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/destinations/{id}");
    }
}