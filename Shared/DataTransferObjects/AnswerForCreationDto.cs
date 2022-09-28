using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record AnswerForCreationDto
    {
        public Guid QuestionId { get; init; }
        public string? QuestionTitle { get; init; }
        public int ChoiceId { get; init; }
        public string? ChoiceTitle { get; init; }

    }
}
