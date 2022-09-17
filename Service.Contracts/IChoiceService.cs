using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IChoiceService
    {
        Task<IEnumerable<ChoiceDto>> GetChoicesAsync(Guid surveyId, Guid questionId, bool trackChanges);
        Task<ChoiceDto> GetChoiceAsync(Guid surveyId, Guid questionId, int id, bool trackChanges);
        Task<ChoiceDto> CreateChoiceForQuestionAsync(Guid surveyId, Guid questionId, ChoiceForCreationDto choiceForCreation, bool trackChanges);
        Task DeleteChoiceForQuestionAsync(Guid surveyId, Guid questionId, int id, bool trackChanges);
        Task UpdateChoiceForQuestionAsync(Guid surveyId, Guid questionId, int id, ChoiceForUpdateDto choiceForUpdate, bool questionTrackChanges, bool choiceTrackChanges);
    }
}
