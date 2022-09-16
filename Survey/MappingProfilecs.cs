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
            CreateMap<Question, QuestionDto>();
            CreateMap<SurveyForCreationDto, SurveyModel>();
            CreateMap<QuestionForCreationDto, Question>();
            CreateMap<ChoiceForCreationDto, Choice>();
            CreateMap<QuestionForUpdateDto, Question>();
            CreateMap<SurveyForUpdateDto, SurveyModel>();
        }
    }
}
