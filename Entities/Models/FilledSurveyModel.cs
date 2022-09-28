using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FilledSurveyModel
    {
        [Key]
        [Column("FilledSurveyModelId")]
        public Guid Id { get; set; }
        public ICollection<Answer>? Answers { get; set; }

        [ForeignKey(nameof(SurveyModel))]
        public Guid SurveyId { get; set; }
        public SurveyModel? SurveyModel { get; set; }
    }
}
