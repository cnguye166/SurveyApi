using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<SurveyModel>> GetAllSurveysAsync(bool trackChanges);
        Task<SurveyModel> GetSurveyQuestionsChoicesAsync(Guid surveyId, bool trackChanges);



        Task<SurveyModel> GetSurveyAsync(Guid surveyId, bool trackChanges);
        void CreateSurvey(SurveyModel survey);
        void DeleteSurvey(SurveyModel survey);

    }
}
