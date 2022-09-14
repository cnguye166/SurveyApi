using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class Survey
    {
        [Column("SurveyId")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Survey name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}
