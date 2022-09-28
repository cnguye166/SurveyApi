using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISurveyService
    {

        Task<(IEnumerable<SurveyDto> surveys, MetaData metaData)> GetAllSurveysAsync(SurveyParameters surveyParameters, bool trackChanges);
        Task<SurveyQuestionDto> GetSurveyQuestionsChoicesAsync(Guid surveyId, bool trackChanges);

        Task<SurveyDto> GetSurveyAsync(Guid surveyId, bool trackChanges);
        Task<IEnumerable<SurveyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<SurveyDto> CreateSurveyAsync(string userId, SurveyForCreationDto survey);
        Task<(IEnumerable<SurveyDto> surveys, string ids)> CreateSurveyCollectionAsync(IEnumerable<SurveyForCreationDto> surveyCollection);

        Task DeleteSurveyAsync(Guid surveyId, bool trackChanges);
        Task UpdateSurveyAsync(Guid surveyId, SurveyForUpdateDto surveyForUpdate, bool trackChanges);


    }
}
