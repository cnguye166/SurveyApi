using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }

        [ForeignKey(nameof(Choice))]
        public ICollection<int>? ChoicesId { get; set; }


        [ForeignKey(nameof(CompletedSurveyModel))]
        public Guid CompletedSurveyModelId { get; set; }
        public SurveyModel? CompletedSurveyModel { get; set; }
    }
}
