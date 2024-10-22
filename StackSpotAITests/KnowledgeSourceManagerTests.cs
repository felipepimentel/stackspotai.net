using System.Threading.Tasks;
using Xunit;
using StackSpotAI;
using Moq;

namespace StackSpotAITests
{
    public class KnowledgeSourceManagerTests
    {
        [Fact]
        public async Task CreateKnowledgeSource_ShouldReturnCreatedSource()
        {
            var mockClient = new Mock<StackSpotAIClient>("client_id", "client_secret");
            var knowledgeSourceManager = new KnowledgeSourceManager(mockClient.Object);

            var newSource = new KnowledgeSource
            {
                Id = "source_id",
                Name = "New Source",
                Description = "A test source"
            };

            mockClient.Setup(client => client.PostAsync<KnowledgeSource>("knowledge-source", newSource))
                .ReturnsAsync(newSource);

            var createdSource = await knowledgeSourceManager.CreateKnowledgeSourceAsync(newSource);

            Assert.Equal("New Source", createdSource.Name);
        }
    }
}
