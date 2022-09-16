using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record QuestionDto
    {
        public Guid id { get; init; }
        public string? Title { get; init; }
    }
}
