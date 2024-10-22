using System.Text.RegularExpressions;
using StackspotAI.Common;

namespace StackspotAI.Models
{
    public class KnowledgeSource
    {
        public string Id { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        private KnowledgeSource() { }

        public static Result<KnowledgeSource> Create(string name, string description)
        {
            var knowledgeSource = new KnowledgeSource();
            var nameResult = knowledgeSource.SetName(name);
            if (!nameResult.IsSuccess) return Result<KnowledgeSource>.Failure(nameResult.Error!);

            var descriptionResult = knowledgeSource.SetDescription(description);
            if (!descriptionResult.IsSuccess) return Result<KnowledgeSource>.Failure(descriptionResult.Error!);

            return Result<KnowledgeSource>.Success(knowledgeSource);
        }

        public Result<bool> SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<bool>.Failure("Name cannot be empty.");
            if (name.Length > 100)
                return Result<bool>.Failure("Name cannot be longer than 100 characters.");
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s-]+$"))
                return Result<bool>.Failure("Name can only contain alphanumeric characters, spaces, and hyphens.");

            Name = name;
            return Result<bool>.Success(true);
        }

        public Result<bool> SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Result<bool>.Failure("Description cannot be empty.");
            if (description.Length > 1000)
                return Result<bool>.Failure("Description cannot be longer than 1000 characters.");

            Description = description;
            return Result<bool>.Success(true);
        }
    }
}
