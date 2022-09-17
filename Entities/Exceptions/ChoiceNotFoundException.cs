using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ChoiceNotFoundException : NotFoundException
    {
        public ChoiceNotFoundException(int choiceId) : base($"Choice with id: {choiceId} doesn't exist in the database.")
        {
        }
    }
}
