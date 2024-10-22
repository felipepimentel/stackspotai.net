using System.Threading;
using System.Threading.Tasks;
using StackSpotAI.Common;

namespace StackSpotAI.Interfaces
{
    public interface IStackSpotHttpClient
    {
        Task<Result<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<Result<T>> PostAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default);
        Task<Result<T>> PutAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default);
    }
}
