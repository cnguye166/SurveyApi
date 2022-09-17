using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISurveyService
    {

        Task<IEnumerable<SurveyDto>> GetAllSurveysAsync(bool trackChanges);
        Task<SurveyQuestionDto> GetSurveyQuestionsChoicesAsync(Guid surveyId, bool trackChanges);

        Task<SurveyDto> GetSurveyAsync(Guid surveyId, bool trackChanges);
        Task<SurveyDto> CreateSurveyAsync(SurveyForCreationDto survey);
        Task DeleteSurveyAsync(Guid surveyId, bool trackChanges);
        Task UpdateSurveyAsync(Guid surveyId, SurveyForUpdateDto surveyForUpdate, bool trackChanges);

    }
}
