using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;
using System.Text;

namespace StackSpotAI.IntegrationTests
{
    public class KnowledgeSourceTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public KnowledgeSourceTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateKnowledgeSource_ReturnsCreatedResult()
        {
            // Arrange
            var content = new StringContent(JsonConvert.SerializeObject(new { Name = "Test", Description = "Test Description" }), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/knowledgesource", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
