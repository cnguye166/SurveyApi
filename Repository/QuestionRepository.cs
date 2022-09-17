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
    internal sealed class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateQuestionForSurvey(Guid surveyId, Question question)
        {
            question.SurveyId = surveyId;
            Create(question);
        }

        public void DeleteQuestion(Question question)
        {
            Delete(question);
        }

        public async Task<Question> GetQuestionAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.SurveyId.Equals(surveyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Question> GetQuestionChoicesAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(q => q.SurveyId.Equals(surveyId) && q.Id.Equals(id), trackChanges)
                .Include(q => q.Choices)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(Guid surveyId, bool trackChanges)
        {
            return await FindByCondition(e => e.SurveyId.Equals(surveyId), trackChanges).ToListAsync();
        }

      
    }
}
