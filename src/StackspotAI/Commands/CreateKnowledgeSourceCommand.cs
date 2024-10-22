using MediatR;
using StackspotAI.Common;
using StackspotAI.Models;
using StackspotAI.Interfaces;

namespace StackspotAI.Commands
{
    public record CreateKnowledgeSourceCommand(string Name, string Description) : IRequest<Result<KnowledgeSource>>;

    public class CreateKnowledgeSourceCommandHandler : IRequestHandler<CreateKnowledgeSourceCommand, Result<KnowledgeSource>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateKnowledgeSourceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<KnowledgeSource>> Handle(CreateKnowledgeSourceCommand request, CancellationToken cancellationToken)
        {
            var knowledgeSourceResult = KnowledgeSource.Create(request.Name, request.Description);
            if (!knowledgeSourceResult.IsSuccess)
                return Result<KnowledgeSource>.Failure(knowledgeSourceResult.Error!);

            var createResult = await _unitOfWork.KnowledgeSources.CreateAsync(knowledgeSourceResult.Value!, cancellationToken);
            if (!createResult.IsSuccess)
                return Result<KnowledgeSource>.Failure(createResult.Error!);

            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return saveResult.IsSuccess
                ? Result<KnowledgeSource>.Success(createResult.Value!)
                : Result<KnowledgeSource>.Failure(saveResult.Error!);
        }
    }
}
