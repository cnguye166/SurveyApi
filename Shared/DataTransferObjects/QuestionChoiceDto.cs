namespace Shared.DataTransferObjects
{
    public record QuestionChoiceDto
    {
        public Guid Id { get; init; }
        public Guid SurveyId { get; init; }

        public string? Title { get; init; }
        public IEnumerable<ChoiceDto>? Choices { get; init; }
    }
}
