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
    internal sealed class FilledSurveyRepository : RepositoryBase<FilledSurveyModel>, IFilledSurveyRepository
    {
        public FilledSurveyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFilledSurveyForSurvey(Guid surveyId, FilledSurveyModel filledSurvey)
        {
            filledSurvey.SurveyId = surveyId;
            Create(filledSurvey);
        }

        public async Task<FilledSurveyModel> GetFilledSurveyAnswersAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.SurveyId.Equals(surveyId) && e.Id.Equals(id), trackChanges)
                .Include(e => e.Answers)
                .SingleOrDefaultAsync();
        }

        public async Task<FilledSurveyModel> GetFilledSurveyAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.SurveyId.Equals(surveyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<FilledSurveyModel>> GetFilledSurveysAsync(Guid surveyId, bool trackChanges)
        {
            return await FindByCondition(e => e.SurveyId.Equals(surveyId), trackChanges).ToListAsync();
        }
    }
}
