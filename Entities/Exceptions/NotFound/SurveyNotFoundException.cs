using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.NotFound
{
    public class SurveyNotFoundException : NotFoundException
    {
        public SurveyNotFoundException(Guid surveyId) : base($"The survey with id: {surveyId} doesn't exist in the database.")
        {
        }
    }
}
