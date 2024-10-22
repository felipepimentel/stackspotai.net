using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StackSpotAI
{
    public class TokenManager
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly HttpClient _httpClient;
        private readonly string _authUrl = "https://auth.stackspot.com/oauth/token";

        public TokenManager(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = new HttpClient();
        }

        public async Task<string> GenerateTokenAsync()
        {
            var data = new
            {
                grant_type = "client_credentials",
                client_id = _clientId,
                client_secret = _clientSecret
            };

            var response = await _httpClient.PostAsJsonAsync(_authUrl, data);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jsonResponse)!;
            if (tokenResponse == null || tokenResponse.AccessToken == null)
            {
                throw new InvalidOperationException("Failed to generate access token.");
            }
            return tokenResponse.AccessToken;
        }

        private class TokenResponse
        {
            [JsonProperty("access_token")]
            public string? AccessToken { get; set; }
        }
    }
}
