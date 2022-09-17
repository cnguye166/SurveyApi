using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class ChoiceRepository : RepositoryBase<Choice>, IChoiceRepository
    {
        public ChoiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateChoiceForQuestion(Guid questionId, Choice choice)
        {
            choice.QuestionId = questionId;
            Create(choice);
        }

        public void DeleteChoice(Choice choice)
        {
            Delete(choice);
        }

        public async Task<Choice> GetChoiceAsync(Guid questionId, int id, bool trackChanges)
        {
            return await FindByCondition(c => c.QuestionId.Equals(questionId) && c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Choice>> GetChoicesAsync(Guid questionId, bool trackChanges)
        {
            return await FindByCondition(c => c.QuestionId.Equals(questionId), trackChanges).ToListAsync();
        }
    }
}
