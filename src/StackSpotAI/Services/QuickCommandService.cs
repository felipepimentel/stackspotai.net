using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackSpotAI.Interfaces;
using StackSpotAI.Entities;
using StackSpotAI.Common;

namespace StackSpotAI.Services
{
    public class QuickCommandService : IQuickCommandService
    {
        private readonly IStackSpotHttpClient _client;
        private readonly ILogger<QuickCommandService> _logger;

        public QuickCommandService(IStackSpotHttpClient client, ILogger<QuickCommandService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<QuickCommand>> CreateRemoteAsync(QuickCommand commandData, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _client.PostAsync<QuickCommand>("quick-command/remote", commandData, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating remote quick command");
                return Result<QuickCommand>.Failure($"Failed to create remote quick command: {ex.Message}");
            }
        }

        public async Task<Result<QuickCommandStatus>> GetStatusAsync(string commandId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _client.GetAsync<QuickCommandStatus>($"quick-command/status/{commandId}", cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving quick command status");
                return Result<QuickCommandStatus>.Failure($"Failed to retrieve quick command status: {ex.Message}");
            }
        }
    }
}
