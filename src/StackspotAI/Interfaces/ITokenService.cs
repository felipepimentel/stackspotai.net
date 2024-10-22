using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;

namespace StackspotAI.Interfaces
{
    public interface ITokenService
    {
        Task<Result<string>> GetTokenAsync(CancellationToken cancellationToken = default);
    }
}
