using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record FilledSurveyForCreationDto
    {
        public IEnumerable<AnswerForCreationDto>? Answers { get; init; }
    }

}
