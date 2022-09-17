using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Survey
{
    public class MappingProfilecs : Profile
    {
        public MappingProfilecs()
        {
            CreateMap<SurveyModel, SurveyDto>();
            CreateMap<SurveyForCreationDto, SurveyModel>();
            CreateMap<SurveyForUpdateDto, SurveyModel>();
            CreateMap<SurveyModel, SurveyQuestionDto>();

            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuestionChoiceDto>();
            CreateMap<QuestionForCreationDto, Question>();
            CreateMap<QuestionForUpdateDto, Question>();

            CreateMap<Choice, ChoiceDto>();
            CreateMap<ChoiceForCreationDto, Choice>();
            CreateMap<ChoiceForUpdateDto, Choice>();
        }
    }
}
