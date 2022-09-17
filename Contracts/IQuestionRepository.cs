using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(Guid surveyId, bool trackChanges);
        Task<Question> GetQuestionChoicesAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<Question> GetQuestionAsync(Guid surveyId, Guid id, bool trackChanges);
        void CreateQuestionForSurvey(Guid surveyId, Question question);
        void DeleteQuestion(Question question);

    }
}
