using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record QuestionForCreationDto 
    {
        [Required(ErrorMessage = "Question Title is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Title is 200 characters.")]
        public string? Title { get; init; }
        public IEnumerable<ChoiceForCreationDto>? Choices { get; init; }
    };

}
