using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record QuestionChoiceDto
    {
        public Guid id { get; init; }
        public Guid surveyId { get; init; }

        public string? Title { get; init; }
        public IEnumerable<ChoiceDto> Choices { get; init; }
    }
}
