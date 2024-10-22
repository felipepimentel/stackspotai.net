using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;

namespace StackspotAI.Interfaces
{
    public interface IStackspotHttpClient
    {
        Task<Result<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<Result<T>> PostAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default);
        Task<Result<T>> PutAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default);
    }
}
