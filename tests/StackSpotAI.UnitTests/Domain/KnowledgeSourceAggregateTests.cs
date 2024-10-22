using Xunit;
using StackSpotAI.Domain.Aggregates;
using StackSpotAI.Domain.Events;

namespace StackSpotAI.UnitTests.Domain
{
    public class KnowledgeSourceAggregateTests
    {
        [Fact]
        public void Create_ShouldCreateKnowledgeSourceAndAddCreatedEvent()
        {
            // Arrange
            var name = "Test Knowledge Source";
            var description = "This is a test knowledge source";

            // Act
            var knowledgeSource = KnowledgeSourceAggregate.Create(name, description);

            // Assert
            Assert.Equal(name, knowledgeSource.Name);
            Assert.Equal(description, knowledgeSource.Description);
            Assert.Single(knowledgeSource.DomainEvents);
            Assert.IsType<KnowledgeSourceCreatedEvent>(knowledgeSource.DomainEvents.First());
        }

        [Fact]
        public void Update_ShouldUpdateKnowledgeSourceAndAddUpdatedEvent()
        {
            // Arrange
            var knowledgeSource = KnowledgeSourceAggregate.Create("Original Name", "Original Description");
            knowledgeSource.ClearDomainEvents();

            var newName = "Updated Name";
            var newDescription = "Updated Description";

            // Act
            knowledgeSource.Update(newName, newDescription);

            // Assert
            Assert.Equal(newName, knowledgeSource.Name);
            Assert.Equal(newDescription, knowledgeSource.Description);
            Assert.Single(knowledgeSource.DomainEvents);
            Assert.IsType<KnowledgeSourceUpdatedEvent>(knowledgeSource.DomainEvents.First());
        }
    }
}
