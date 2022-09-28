using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record QuestionDto
    {
        public Guid Id { get; init; }
        public Guid SurveyId { get; init; }
        public string? Title { get; init; }
    }
}
