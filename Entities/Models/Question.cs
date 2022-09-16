using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class Question
    {
        [Column("QuestionId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Question Title is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Title is 200 characters.")]
        public string? Title { get; set; }

        public byte[]? OptionalImage { get; set; }

        public ICollection<Choice>? Choices { get; set; }

        [ForeignKey(nameof(Survey))]
        public Guid SurveyId {get; set; }
        public SurveyModel? Survey { get; set; }
    }

}
