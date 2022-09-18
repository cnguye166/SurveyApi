using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SurveyQuestionDto
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Topic { get; init; }

        public IEnumerable<QuestionChoiceDto>? Questions { get; init; }
    }
}
