using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class QuestionService : IQuestionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public QuestionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync(Guid surveyId, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);

            var questions = await _repository.Question.GetQuestionsAsync(surveyId, trackChanges);
            var questionDto = _mapper.Map<IEnumerable<QuestionDto>>(questions);

            return questionDto;
        }

        public async Task<QuestionDto> GetQuestionAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);
            var question = await _repository.Question.GetQuestionAsync(surveyId, id, trackChanges);

            if (question is null)
            {
                throw new QuestionNotFoundException(id);
            }
            var questionDto = _mapper.Map<QuestionDto>(question);

            return questionDto;
        }



        public async Task<QuestionDto> CreateQuestionForSurveyAsync(Guid surveyId, QuestionForCreationDto questionForCreation, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);

            var questionEntity = _mapper.Map<Question>(questionForCreation);
            _repository.Question.CreateQuestionForSurvey(surveyId, questionEntity);
            await _repository.SaveAsync();

            var questionDbo = _mapper.Map<QuestionDto>(questionEntity);
            return questionDbo;

            
        }

        public async Task DeleteQuestionForSurveyAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);

            var question = await _repository.Question.GetQuestionAsync(surveyId, id, trackChanges);

            if (question is null)
                throw new QuestionNotFoundException(id);

            _repository.Question.DeleteQuestion(question);
            await _repository.SaveAsync();

        }

        public async Task UpdateQuestionForSurveyAsync(Guid surveyId, Guid id, QuestionForUpdateDto questionForUpdate, 
            bool surveyTrackChanges, bool questionTrackChanges)
        {
            await CheckIfSurveyExists(surveyId, surveyTrackChanges);


            var question = await _repository.Question.GetQuestionAsync(surveyId, id, questionTrackChanges);
            if (question is null)
                throw new QuestionNotFoundException(id);

            _mapper.Map(questionForUpdate, question);
            await _repository.SaveAsync();

        
        }

        public async Task<QuestionChoiceDto> GetQuestionChoicesAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);

            var question = await _repository.Question.GetQuestionChoicesAsync(surveyId, id, trackChanges);
            if (question is null)
            {
                throw new QuestionNotFoundException(id);
            }

            var toReturn = _mapper.Map<QuestionChoiceDto>(question);

            return toReturn;

        }

        public async Task<IEnumerable<QuestionDto>> GetByIdsAsync(Guid surveyId, IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var questionEntities = await _repository.Question.GetByIdsAsync(surveyId, ids, trackChanges);

            if (questionEntities is null)
                throw new CollectionByIdsBadRequestException();

            var toReturn = _mapper.Map<IEnumerable<QuestionDto>>(questionEntities);

            return toReturn;
        }

        public async Task<(IEnumerable<QuestionDto> questions, string ids)> CreateQuestionCollectionAsync(Guid surveyId, IEnumerable<QuestionForCreationDto> questionCollection)
        {
            if (questionCollection is null)
                throw new QuestionCollectionBadRequest();

            await CheckIfSurveyExists(surveyId, false);


            var questionEntities = _mapper.Map<IEnumerable<Question>>(questionCollection);

            foreach (var questionEntity in questionEntities)
            {
                _repository.Question.CreateQuestionForSurvey(surveyId, questionEntity);
            }
            await _repository.SaveAsync();

            var questionToReturn = _mapper.Map<IEnumerable<QuestionDto>>(questionEntities);
            var ids = string.Join(",", questionToReturn.Select(q => q.Id));

            return (questions: questionToReturn, ids: ids);
            
        }

        private async Task CheckIfSurveyExists(Guid surveyId, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
        }
    }
}
