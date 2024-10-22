using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackSpotAI.Interfaces;
using StackSpotAI.Options;
using StackSpotAI.Common;

namespace StackSpotAI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IStackSpotHttpClient _httpClient;
        private readonly ILogger<TokenService> _logger;
        private readonly StackSpotAIOptions _options;
        private string _cachedToken;
        private DateTime _tokenExpirationTime;

        public TokenService(
            IStackSpotHttpClient httpClient,
            IOptions<StackSpotAIOptions> options,
            ILogger<TokenService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<string>> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _tokenExpirationTime)
            {
                return Result<string>.Success(_cachedToken);
            }

            return await GenerateTokenAsync(cancellationToken);
        }

        private async Task<Result<string>> GenerateTokenAsync(CancellationToken cancellationToken)
        {
            try
            {
                var data = new
                {
                    grant_type = "client_credentials",
                    client_id = _options.ClientId,
                    client_secret = _options.ClientSecret
                };

                var result = await _httpClient.PostAsync<TokenResponse>(_options.AuthUrl, data, cancellationToken);

                if (result.IsSuccess && result.Value?.AccessToken != null)
                {
                    _cachedToken = result.Value.AccessToken;
                    _tokenExpirationTime = DateTime.UtcNow.AddSeconds(result.Value.ExpiresIn);
                    return Result<string>.Success(_cachedToken);
                }
                else
                {
                    return Result<string>.Failure("Failed to generate access token.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating token");
                return Result<string>.Failure($"Failed to generate access token: {ex.Message}");
            }
        }

        private class TokenResponse
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
        }
    }
}
