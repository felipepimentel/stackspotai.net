using System.Threading;
using System.Threading.Tasks;
using StackspotAI.Common;

namespace StackspotAI.Mediator
{
    public interface IMediator
    {
        Task<Result<TResponse>> Send<TResponse>(IRequest<Result<TResponse>> request, CancellationToken cancellationToken = default);
    }

    public interface IRequest<out TResponse> { }
}
