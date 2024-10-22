namespace StackSpotAI
{
    public class StackSpotAIFacade
    {
        private readonly IMediator _mediator;

        public StackSpotAIFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Result<KnowledgeSource>> CreateKnowledgeSourceAsync(string name, string description, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(new CreateKnowledgeSourceCommand(name, description), cancellationToken);
        }

        // Implement other operations similarly
    }
}
