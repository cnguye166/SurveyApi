using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class FilledSurveyModelDto
    {
        public Guid Id { get; init; }
        public Guid SurveyId { get; init; }
    }
}
