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
    public class StackSpotHttpClient : IStackSpotHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly ILogger<StackSpotHttpClient> _logger;
        private readonly StackSpotAIOptions _options;

        public StackSpotHttpClient(
            HttpClient httpClient,
            ITokenService tokenService,
            IOptions<StackSpotAIOptions> options,
            ILogger<StackSpotHttpClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        }

        public async Task<Result<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            await EnsureAuthenticatedAsync(cancellationToken);
            try
            {
                var response = await _httpClient.GetAsync(endpoint, cancellationToken);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
                return Result<T>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while making GET request to {Endpoint}", endpoint);
                return Result<T>.Failure($"Error occurred while making GET request to {endpoint}: {ex.Message}");
            }
        }

        public async Task<Result<T>> PostAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default)
        {
            await EnsureAuthenticatedAsync(cancellationToken);
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, data, cancellationToken);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
                return Result<T>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while making POST request to {Endpoint}", endpoint);
                return Result<T>.Failure($"Error occurred while making POST request to {endpoint}: {ex.Message}");
            }
        }

        public async Task<Result<T>> PutAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default)
        {
            await EnsureAuthenticatedAsync(cancellationToken);
            try
            {
                var response = await _httpClient.PutAsJsonAsync(endpoint, data, cancellationToken);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
                return Result<T>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while making PUT request to {Endpoint}", endpoint);
                return Result<T>.Failure($"Error occurred while making PUT request to {endpoint}: {ex.Message}");
            }
        }

        private async Task EnsureAuthenticatedAsync(CancellationToken cancellationToken)
        {
            var tokenResult = await _tokenService.GetTokenAsync(cancellationToken);
            if (tokenResult.IsSuccess)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResult.Value);
            }
            else
            {
                throw new UnauthorizedAccessException("Failed to obtain authentication token.");
            }
        }
    }
}
