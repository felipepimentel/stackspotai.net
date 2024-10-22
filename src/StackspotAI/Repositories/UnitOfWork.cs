using StackspotAI.Interfaces;
using StackspotAI.Common;
using System.Threading;
using System.Threading.Tasks;

namespace StackspotAI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IKnowledgeSourceRepository KnowledgeSources { get; }
        public IQuickCommandRepository QuickCommands { get; }

        public UnitOfWork(IKnowledgeSourceRepository knowledgeSources, IQuickCommandRepository quickCommands)
        {
            KnowledgeSources = knowledgeSources;
            QuickCommands = quickCommands;
        }

        public Task<Result<bool>> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Implement the actual save changes logic here
            return Task.FromResult(Result<bool>.Success(true));
        }
    }
}
