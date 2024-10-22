using System.Threading;
using System.Threading.Tasks;
using StackSpotAI.Common;

namespace StackSpotAI.Interfaces
{
    public interface ITokenService
    {
        Task<Result<string>> GetTokenAsync(CancellationToken cancellationToken = default);
    }
}
