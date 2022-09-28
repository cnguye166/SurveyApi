using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class SurveyModel
    {
        [Column("SurveyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Creator Id is a required field.")]
        public string? CreatorId { get; set; }
        
        [Required(ErrorMessage = "Survey Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
        public string? Title { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum length for the Topic is 30 characters.")]
        public string? Topic { get; set; }

        public ICollection<Question>? Questions { get; set; }
    }
}
