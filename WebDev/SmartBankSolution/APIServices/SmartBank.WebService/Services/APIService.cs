using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebApplicationMVC.Services
{
    public class APIService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _context;

        public APIService(IHttpClientFactory factory, IHttpContextAccessor context)
        {
            _factory = factory;
            _context = context;
        }

        private void AddToken(HttpClient client)
        {
            var token = _context.HttpContext?.Session?.GetString("JWT");

            if (!string.IsNullOrEmpty(token))
            {
                // ✅ Prevent duplicate header
                if (client.DefaultRequestHeaders.Authorization == null)
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                }
            }
        }

        private HttpClient GetClient(string clientName)
        {
            // ✅ FIXED
            return _factory.CreateClient(clientName);
        }

        // ================= GET =================

        public async Task<(bool Success, int StatusCode, string Content, T Data)>
            GetAsync<T>(string clientName, string url)
        {
            var client = GetClient(clientName);
            AddToken(client);

            try
            {
                var response = await client.GetAsync(url);
                var respContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return (false, (int)response.StatusCode, respContent, default);
                }

                var data = JsonConvert.DeserializeObject<T>(respContent);
                return (true, (int)response.StatusCode, respContent, data);
            }
            catch (HttpRequestException ex)
            {
                return (false, 0, ex.Message, default);
            }
        }

        // ================= POST (Simple) =================

        public async Task<T> PostAsync<T>(string clientName, string url, object obj)
        {
            var (success, _, _, data) =
                await PostWithResponseAsync<T>(clientName, url, obj);

            return success ? data : default;
        }

        // ================= POST (Detailed) =================

        public async Task<(bool Success, int StatusCode, string Content, T Data)>
            PostWithResponseAsync<T>(string clientName, string url, object obj)
        {
            var client = GetClient(clientName);
            AddToken(client);

            var content = new StringContent(
                JsonConvert.SerializeObject(obj),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await client.PostAsync(url, content);
                var respContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return (false, (int)response.StatusCode, respContent, default);
                }

                T data = default;

                try
                {
                    data = JsonConvert.DeserializeObject<T>(respContent);
                }
                catch
                {
                    // Ignore deserialization issues
                }

                return (true, (int)response.StatusCode, respContent, data);
            }
            catch (HttpRequestException ex)
            {
                return (false, 0, ex.Message, default);
            }
        }
    }
}