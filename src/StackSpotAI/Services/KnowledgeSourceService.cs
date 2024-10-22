using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackSpotAI.Interfaces;
using StackSpotAI.Entities;
using StackSpotAI.Common;
using StackSpotAI.Models;

namespace StackSpotAI.Services
{
    public class KnowledgeSourceService : IKnowledgeSourceService
    {
        private readonly IStackSpotHttpClient _client;
        private readonly ILogger<KnowledgeSourceService> _logger;

        public KnowledgeSourceService(IStackSpotHttpClient client, ILogger<KnowledgeSourceService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<KnowledgeSource>> CreateAsync(KnowledgeSource knowledgeSourceData, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _client.PostAsync<KnowledgeSource>("knowledge-source", knowledgeSourceData, cancellationToken);
                return result.IsSuccess
                    ? Result<KnowledgeSource>.Success(result.Value!)
                    : Result<KnowledgeSource>.Failure(result.Error!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating knowledge source");
                return Result<KnowledgeSource>.Failure($"Failed to create knowledge source: {ex.Message}");
            }
        }

        public async Task<Result<KnowledgeSource>> UpdateAsync(string knowledgeSourceId, KnowledgeSource updateData, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _client.PutAsync<KnowledgeSource>($"knowledge-source/{knowledgeSourceId}", updateData, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating knowledge source");
                return Result<KnowledgeSource>.Failure($"Failed to update knowledge source: {ex.Message}");
            }
        }

        public async Task<Result<KnowledgeSource>> GetAsync(string knowledgeSourceId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _client.GetAsync<KnowledgeSource>($"knowledge-source/{knowledgeSourceId}", cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving knowledge source");
                return Result<KnowledgeSource>.Failure($"Failed to retrieve knowledge source: {ex.Message}");
            }
        }
    }
}
