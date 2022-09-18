
namespace Shared.DataTransferObjects
{
    public record QuestionChoiceDto
    {
        public Guid id { get; init; }
        public Guid surveyId { get; init; }

        public string? Title { get; init; }
        public IEnumerable<ChoiceDto>? Choices { get; init; }
    }
}
