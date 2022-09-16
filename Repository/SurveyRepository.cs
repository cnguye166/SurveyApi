﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class SurveyRepository : RepositoryBase<SurveyModel>, ISurveyRepository
    {
        public SurveyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {


        }

        public void CreateSurvey(SurveyModel survey)
        {
            Create(survey);
        }

        public void DeleteSurvey(SurveyModel survey)
        {
            Delete(survey);
        }

        public async Task<IEnumerable<SurveyModel>> GetAllSurveysAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.Title)
                .ToListAsync();
        }

        public async Task<SurveyModel> GetSurveyAsync(Guid surveyId, bool trackChanges)
        {
            return await FindByCondition(s => s.Id.Equals(surveyId), trackChanges).SingleOrDefaultAsync();
        }
    }
}