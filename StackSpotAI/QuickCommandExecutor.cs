using System.Threading.Tasks;

namespace StackSpotAI
{
    public class QuickCommandExecutor
    {
        private readonly StackSpotAIClient _client;

        public QuickCommandExecutor(StackSpotAIClient client)
        {
            _client = client;
        }

        public async Task<QuickCommand> CreateRemoteQuickCommandAsync(QuickCommand commandData)
        {
            return await _client.PostAsync<QuickCommand>("quick-command/remote", commandData);
        }

        public async Task<QuickCommandStatus> GetQuickCommandStatusAsync(string commandId)
        {
            return await _client.GetAsync<QuickCommandStatus>($"quick-command/status/{commandId}");
        }
    }

    public class QuickCommand
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Command { get; set; }
        public string? Status { get; set; }
    }


    public class QuickCommandStatus
    {
        public required string Status { get; set; }
    }
}
