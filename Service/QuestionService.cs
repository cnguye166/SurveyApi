using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var questions = await _repository.Question.GetQuestionsAsync(surveyId, trackChanges);
            var questionDto = _mapper.Map<IEnumerable<QuestionDto>>(questions);

            return questionDto;
        }

        public async Task<QuestionDto> GetQuestionAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
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
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var questionEntity = _mapper.Map<Question>(questionForCreation);
            _repository.Question.CreateQuestionForSurvey(surveyId, questionEntity);
            await _repository.SaveAsync();

            var questionDbo = _mapper.Map<QuestionDto>(questionEntity);
            return questionDbo;

            
        }

        public async Task DeleteQuestionForSurveyAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);

            if (survey is null)
                throw new SurveyNotFoundException(surveyId);

            var question = await _repository.Question.GetQuestionAsync(surveyId, id, trackChanges);

            if (question is null)
                throw new QuestionNotFoundException(id);

            _repository.Question.DeleteQuestion(question);
            await _repository.SaveAsync();

        }

        public async Task UpdateQuestionForSurveyAsync(Guid surveyId, Guid id, QuestionForUpdateDto questionForUpdate, 
            bool surveyTrackChanges, bool questionTrackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, surveyTrackChanges);

            if (survey is null)
                throw new SurveyNotFoundException(surveyId);

            var question = await _repository.Question.GetQuestionAsync(surveyId, id, questionTrackChanges);
            if (question is null)
                throw new QuestionNotFoundException(id);

            _mapper.Map(questionForUpdate, question);
            await _repository.SaveAsync();

        
        }
    }
}
