using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    public record FilledSurveyAnswerDto
    {
        public Guid Id { get; init; }
        public Guid SurveyId { get; init; }
        public IEnumerable<AnswerDto>? Answers { get; init; }
    }
}
