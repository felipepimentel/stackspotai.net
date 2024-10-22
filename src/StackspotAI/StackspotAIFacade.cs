using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StackspotAI.Common;
using StackspotAI.Models;
using StackspotAI.Commands;

namespace StackspotAI
{
    public class StackspotAIFacade
    {
        private readonly IMediator _mediator;

        public StackspotAIFacade(IMediator mediator)
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
