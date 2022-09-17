using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IChoiceRepository
    {
        Task<IEnumerable<Choice>> GetChoicesAsync(Guid questionId, bool trackChanges);
        Task<Choice> GetChoiceAsync(Guid questionId, int id, bool trackChanges);
        void CreateChoiceForQuestion(Guid questionId, Choice choice);
        void DeleteChoice(Choice choice);
    }
}
