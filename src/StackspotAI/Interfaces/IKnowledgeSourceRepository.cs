using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;
using StackspotAI.Models;

namespace StackspotAI.Interfaces
{
    public interface IKnowledgeSourceRepository
    {
        Task<Result<KnowledgeSource>> CreateAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> UpdateAsync(string id, KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}
