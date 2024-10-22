using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;


namespace StackSpotAI
{
    public class StackSpotAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.stackspot.com";

        public StackSpotAIClient(string clientId, string clientSecret)
        {
            _httpClient = new HttpClient();
            var tokenManager = new TokenManager(clientId, clientSecret);
            string token = tokenManager.GenerateTokenAsync().GetAwaiter().GetResult();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException("Null response from API.");
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException("Null response from API.");
        }

        public async Task<T> PutAsync<T>(string endpoint, object data)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{endpoint}", data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException("Null response from API.");
        }
    }
}
