using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Choice
    {
        [Key]
        [Column("ChoiceId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Choice title is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for an answer choice is 200 characters.")]
        public string? Title { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
