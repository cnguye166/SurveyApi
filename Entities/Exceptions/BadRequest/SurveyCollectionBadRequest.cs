using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.BadRequest
{
    public sealed class SurveyCollectionBadRequest : BadRequestException
    {
        public SurveyCollectionBadRequest() : base("Survey collection sent from a client is null.")
        {
        }
    }
}
