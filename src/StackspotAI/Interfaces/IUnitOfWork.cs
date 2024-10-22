using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;

namespace StackspotAI.Interfaces
{
    public interface IUnitOfWork
    {
        IKnowledgeSourceRepository KnowledgeSources { get; }
        IQuickCommandRepository QuickCommands { get; }
        Task<Result<bool>> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
