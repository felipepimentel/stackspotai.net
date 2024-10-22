using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;
using StackspotAI.Models;

namespace StackspotAI.Interfaces
{
    public interface IQuickCommandService
    {
        Task<Result<QuickCommand>> CreateRemoteAsync(QuickCommand commandData, CancellationToken cancellationToken = default);
        Task<Result<QuickCommandStatus>> GetStatusAsync(string commandId, CancellationToken cancellationToken = default);
    }
}
