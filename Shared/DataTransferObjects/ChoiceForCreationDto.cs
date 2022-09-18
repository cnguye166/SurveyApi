using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ChoiceForCreationDto 
    {
        [Required(ErrorMessage = "Choice title is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for an answer choice is 200 characters.")]
        public string? Title { get; init; } 
    };
}
