using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsAsync(Guid surveyId, bool trackChanges);
        Task<QuestionDto> GetQuestionAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<QuestionChoiceDto> GetQuestionChoicesAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<IEnumerable<QuestionDto>> GetByIdsAsync(Guid surveyId, IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<QuestionDto> questions, string ids)> CreateQuestionCollectionAsync(Guid surveyId, IEnumerable<QuestionForCreationDto> questionCollection);
        Task<QuestionDto> CreateQuestionForSurveyAsync(Guid surveyId, QuestionForCreationDto questionForCreation, bool trackChanges);
        Task DeleteQuestionForSurveyAsync(Guid surveyId, Guid id, bool trackChanges);

        Task UpdateQuestionForSurveyAsync(Guid surveyId, Guid id, QuestionForUpdateDto questionForUpdate, bool surveyTrackChanges, bool questionTrackChanges);
    }
}
