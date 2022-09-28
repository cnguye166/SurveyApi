using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SurveyForCreationDto
    {


        [Required(ErrorMessage = "Survey Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
        public string? Title { get; init; }

        [MaxLength(30, ErrorMessage = "Maximum length for the Topic is 30 characters.")]
        public string? Topic { get; init; }

        public IEnumerable<QuestionForCreationDto>? Questions { get; init; }

    };

}
