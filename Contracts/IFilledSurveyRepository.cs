using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFilledSurveyRepository
    {
        Task<IEnumerable<FilledSurveyModel>> GetFilledSurveysAsync(Guid surveyId, bool trackChanges);
        Task<FilledSurveyModel> GetFilledSurveyAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<FilledSurveyModel> GetFilledSurveyAnswersAsync(Guid surveyId, Guid id, bool trackChanges);
        void CreateFilledSurveyForSurvey(Guid surveyId, FilledSurveyModel filledSurvey);

    }
}
