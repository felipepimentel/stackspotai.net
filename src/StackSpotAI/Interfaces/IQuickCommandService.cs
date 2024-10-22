using System.Threading;
using System.Threading.Tasks;
using StackSpotAI.Entities;
using StackSpotAI.Common;

namespace StackSpotAI.Interfaces
{
    public interface IQuickCommandService
    {
        Task<Result<QuickCommand>> CreateRemoteAsync(QuickCommand commandData, CancellationToken cancellationToken = default);
        Task<Result<QuickCommandStatus>> GetStatusAsync(string commandId, CancellationToken cancellationToken = default);
    }
}
