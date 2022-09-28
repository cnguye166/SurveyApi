using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class SurveyRepositoryExtensions
    {
        public static IQueryable<SurveyModel> Search (this IQueryable<SurveyModel> surveys, string searchId)
        {
            if (string.IsNullOrWhiteSpace(searchId))
            {
                return surveys;
            }
            var lowerCase = searchId.Trim().ToLower();
            return surveys.Where (s => s.CreatorId.ToLower().Contains(searchId));
        }
    }
}
