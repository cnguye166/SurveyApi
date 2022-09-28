using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Authentication;

namespace Survey
{
    public class MappingProfilecs : Profile
    {
        public MappingProfilecs()
        {

            CreateMap<SurveyModel, SurveyDto>();
            CreateMap<(string userId, SurveyForCreationDto surveyForCreation), SurveyModel>()
                .ForMember(dist => dist.CreatorId, opt => opt.MapFrom(src => src.userId))
                .ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.surveyForCreation.Title))
                .ForMember(dist => dist.Topic, opt => opt.MapFrom(src => src.surveyForCreation.Topic))
                .ForMember(dist => dist.Questions, opt => opt.MapFrom(src => src.surveyForCreation.Questions));


            CreateMap<SurveyForUpdateDto, SurveyModel>();
            CreateMap<SurveyModel, SurveyQuestionDto>();

            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuestionChoiceDto>();
            CreateMap<QuestionForCreationDto, Question>();
            CreateMap<QuestionForUpdateDto, Question>();

            CreateMap<Choice, ChoiceDto>();
            CreateMap<ChoiceForCreationDto, Choice>();
            CreateMap<ChoiceForUpdateDto, Choice>();

            CreateMap<FilledSurveyModel, FilledSurveyModelDto>();
            CreateMap<FilledSurveyForCreationDto, FilledSurveyModel>();
            CreateMap<FilledSurveyModel, FilledSurveyAnswerDto>();


            CreateMap<(Question question, Choice choice), AnswerForCreationDto>()
                .ForMember(dist => dist.QuestionTitle, opt => opt.MapFrom(src => src.question.Title))
                .ForMember(dist => dist.QuestionId, opt => opt.MapFrom(src => src.question.Id))
                .ForMember(dist => dist.ChoiceTitle, opt => opt.MapFrom(src => src.choice.Title))
                .ForMember(dist => dist.ChoiceId, opt => opt.MapFrom(src => src.choice.Id));

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerForCreationDto, Answer>();


            CreateMap<UserForRegistrationDto, User>();




        }
    }
}
