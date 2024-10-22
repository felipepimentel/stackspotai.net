using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;
using StackspotAI.Models;

namespace StackspotAI.Interfaces
{
    public interface IQuickCommandRepository
    {
        Task<Result<QuickCommand>> CreateAsync(QuickCommand quickCommand, CancellationToken cancellationToken = default);
        Task<Result<QuickCommandStatus>> GetStatusAsync(string id, CancellationToken cancellationToken = default);
    }
}
