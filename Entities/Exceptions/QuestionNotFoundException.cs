using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class QuestionNotFoundException : NotFoundException
    {
        public QuestionNotFoundException(Guid questionId) : base($"Question with id: {questionId} doesn't exist in the database.")
        {
        }
    }
}
