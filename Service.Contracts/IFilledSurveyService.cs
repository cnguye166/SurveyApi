using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFilledSurveyService
    {
        Task<IEnumerable<FilledSurveyModelDto>> GetFilledSurveysAsync(Guid surveyId, bool trackChanges);
        Task<FilledSurveyModelDto> GetFilledSurveyAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<FilledSurveyAnswerDto> GetFilledSurveyAnswersAsync(Guid surveyId, Guid id, bool trackChanges);
        Task<FilledSurveyModelDto> CreateFilledSurveyForSurveyAsync(Guid surveyId, FilledSurveyForCreationDto filledSurveyForCreation, bool trackChanges);

    }
}
