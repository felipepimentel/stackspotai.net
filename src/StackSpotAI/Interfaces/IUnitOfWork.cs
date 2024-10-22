namespace StackSpotAI.Interfaces
{
    public interface IUnitOfWork
    {
        IKnowledgeSourceRepository KnowledgeSources { get; }
        IQuickCommandRepository QuickCommands { get; }
        Task<Result<bool>> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
