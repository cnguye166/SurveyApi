using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISurveyRepository
    {
        Task<PagedList<SurveyModel>> GetAllSurveysAsync(SurveyParameters surveyParameters, bool trackChanges);
        Task<SurveyModel> GetSurveyQuestionsChoicesAsync(Guid surveyId, bool trackChanges);

        Task<IEnumerable<SurveyModel>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);


        Task<SurveyModel> GetSurveyAsync(Guid surveyId, bool trackChanges);
        void CreateSurvey(SurveyModel survey);
        void DeleteSurvey(SurveyModel survey);

    }
}
