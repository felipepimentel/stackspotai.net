using StackspotAI.Interfaces;
using StackspotAI.Models;
using StackspotAI.Common;
using System.Threading;
using System.Threading.Tasks;

namespace StackspotAI.Repositories
{
    public class QuickCommandRepository : IQuickCommandRepository
    {
        private readonly IStackspotHttpClient _httpClient;

        public QuickCommandRepository(IStackspotHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<QuickCommand>> CreateAsync(QuickCommand quickCommand, CancellationToken cancellationToken = default)
        {
            return _httpClient.PostAsync<QuickCommand>("quick-command", quickCommand, cancellationToken);
        }

        public Task<Result<QuickCommandStatus>> GetStatusAsync(string id, CancellationToken cancellationToken = default)
        {
            return _httpClient.GetAsync<QuickCommandStatus>($"quick-command/status/{id}", cancellationToken);
        }
    }
}
