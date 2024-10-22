namespace StackSpotAI.Interfaces
{
    public interface IKnowledgeSourceRepository
    {
        Task<Result<KnowledgeSource>> CreateAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> UpdateAsync(string id, KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}
