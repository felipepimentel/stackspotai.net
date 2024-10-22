using StackspotAI.Interfaces;
using StackspotAI.Models;
using StackspotAI.Common;
using System.Threading;
using System.Threading.Tasks;

namespace StackspotAI.Repositories
{
    public class KnowledgeSourceRepository : IKnowledgeSourceRepository
    {
        private readonly IStackspotHttpClient _httpClient;

        public KnowledgeSourceRepository(IStackspotHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<KnowledgeSource>> CreateAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            return _httpClient.PostAsync<KnowledgeSource>("knowledge-source", knowledgeSource, cancellationToken);
        }

        public Task<Result<KnowledgeSource>> UpdateAsync(string id, KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            return _httpClient.PutAsync<KnowledgeSource>($"knowledge-source/{id}", knowledgeSource, cancellationToken);
        }

        public Task<Result<KnowledgeSource>> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return _httpClient.GetAsync<KnowledgeSource>($"knowledge-source/{id}", cancellationToken);
        }
    }
}
