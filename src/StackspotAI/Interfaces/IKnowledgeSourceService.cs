using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;
using StackspotAI.Models;

namespace StackspotAI.Interfaces
{
    public interface IKnowledgeSourceService
    {
        Task<Result<KnowledgeSource>> CreateAsync(KnowledgeSource knowledgeSourceData, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> UpdateAsync(string knowledgeSourceId, KnowledgeSource updateData, CancellationToken cancellationToken = default);
        Task<Result<KnowledgeSource>> GetAsync(string knowledgeSourceId, CancellationToken cancellationToken = default);
    }
}
