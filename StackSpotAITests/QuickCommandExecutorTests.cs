using System.Threading.Tasks;
using Xunit;
using StackSpotAI;
using Moq;

namespace StackSpotAITests
{
    public class QuickCommandExecutorTests
    {
        [Fact]
        public async Task CreateRemoteQuickCommand_ShouldReturnCommand()
        {
            var mockClient = new Mock<StackSpotAIClient>("client_id", "client_secret");
            var quickCommandExecutor = new QuickCommandExecutor(mockClient.Object);

            var newCommand = new QuickCommand
            {
                Id = "command_id",
                Name = "New Command",
                Command = "test command"
            };

            mockClient.Setup(client => client.PostAsync<QuickCommand>("quick-command/remote", newCommand))
                .ReturnsAsync(newCommand);

            var createdCommand = await quickCommandExecutor.CreateRemoteQuickCommandAsync(newCommand);

            Assert.Equal("New Command", createdCommand.Name);
        }
    }
}
