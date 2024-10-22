namespace StackSpotAI.Mediator
{
    public interface IMediator
    {
        Task<Result<TResponse>> Send<TResponse>(IRequest<Result<TResponse>> request, CancellationToken cancellationToken = default);
    }
}
