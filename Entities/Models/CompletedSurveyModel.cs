using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CompletedSurveyModel
    {
        [Column("CompletedSurveyId")]
        public Guid Id { get; set; }
        public ICollection<Answer>? Answer{ get; set; }
        [ForeignKey(nameof(SurveyModel))]
        public Guid SurveyId { get; set; }
        public SurveyModel? SurveyModel { get; set; }
    }
}
