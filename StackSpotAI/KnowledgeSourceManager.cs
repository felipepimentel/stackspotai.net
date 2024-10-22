using System.Threading.Tasks;

namespace StackSpotAI
{
    public class KnowledgeSourceManager
    {
        private readonly StackSpotAIClient _client;

        public KnowledgeSourceManager(StackSpotAIClient client)
        {
            _client = client;
        }

        public async Task<KnowledgeSource> CreateKnowledgeSourceAsync(KnowledgeSource knowledgeSourceData)
        {
            return await _client.PostAsync<KnowledgeSource>("knowledge-source", knowledgeSourceData);
        }

        public async Task<KnowledgeSource> UpdateKnowledgeSourceAsync(string knowledgeSourceId, KnowledgeSource updateData)
        {
            return await _client.PutAsync<KnowledgeSource>($"knowledge-source/{knowledgeSourceId}", updateData);
        }

        public async Task<KnowledgeSource> GetKnowledgeSourceAsync(string knowledgeSourceId)
        {
            return await _client.GetAsync<KnowledgeSource>($"knowledge-source/{knowledgeSourceId}");
        }
    }
    public class KnowledgeSource
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

}
