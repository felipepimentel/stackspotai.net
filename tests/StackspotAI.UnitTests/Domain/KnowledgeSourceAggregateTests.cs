using Xunit;
using StackspotAI.Models;
using StackspotAI.Common;

namespace StackspotAI.UnitTests
{
    public class KnowledgeSourceTests
    {
        [Fact]
        public void Create_ShouldCreateKnowledgeSourceAndAddCreatedEvent()
        {
            // Arrange
            var name = "Test Knowledge Source";
            var description = "This is a test knowledge source";

            // Act
            var result = KnowledgeSource.Create(name, description);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            var knowledgeSource = result.Value;
            Assert.Equal(name, knowledgeSource.Name);
            Assert.Equal(description, knowledgeSource.Description);
        }

        [Fact]
        public void Update_ShouldUpdateKnowledgeSource()
        {
            // Arrange
            var createResult = KnowledgeSource.Create("Original Name", "Original Description");
            Assert.True(createResult.IsSuccess);
            Assert.NotNull(createResult.Value);
            var originalKnowledgeSource = createResult.Value;
            var newName = "Updated Name";
            var newDescription = "Updated Description";

            // Act
            var updateResult = originalKnowledgeSource.SetName(newName);
            updateResult = originalKnowledgeSource.SetDescription(newDescription);

            // Assert
            Assert.True(updateResult.IsSuccess);
            Assert.Equal(newName, originalKnowledgeSource.Name);
            Assert.Equal(newDescription, originalKnowledgeSource.Description);
        }
    }
}
