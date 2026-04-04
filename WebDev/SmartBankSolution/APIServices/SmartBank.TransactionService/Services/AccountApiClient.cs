using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
public class AccountApiClient
{
    private readonly HttpClient _httpClient;

    public AccountApiClient(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("AccountService");
    }

    public async Task DepositAsync(int accountId, decimal amount, string token)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "api/accounts/deposit"); // FIXED ENDPOINT  "api/accounts/{accountId}/deposit"

        request.Content = JsonContent.Create(new
        {
           accountId,   
           amount
        });

        
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Deposit failed: {error}");
        }
    }

    public async Task WithdrawAsync(int accountId, decimal amount, string token)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "api/accounts/withdraw"); // FIXED ENDPOINT  "api/accounts/{accountId}/withdraw"

        request.Content = JsonContent.Create(new
        {
            accountId,   
            amount
        });

        // FORWARD JWT TOKEN
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Withdraw failed: {error}");
        }
    }
}