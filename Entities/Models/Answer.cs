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

        [Required]
        public int? ChoiceId { get; set; }
        public string? ChoiceTitle { get; set; }


        [Required]
        public Guid QuestionId { get; set; }
        public string? QuestionTitle { get; set; }


        [ForeignKey(nameof(FilledSurveyModel))]
        public Guid FilledSurveyModelId { get; set; }
        public FilledSurveyModel? FilledSurveyModel { get; set; }
    }
}
