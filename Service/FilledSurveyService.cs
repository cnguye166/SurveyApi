using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class FilledSurveyService : IFilledSurveyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FilledSurveyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<FilledSurveyModelDto> CreateFilledSurveyForSurveyAsync(Guid surveyId, FilledSurveyForCreationDto filledSurveyForCreation, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);



            var questionsChoices = new List<(Question, Choice)>();


            foreach (AnswerForCreationDto? ids in filledSurveyForCreation.Answers)
            {
                var questionId = ids.QuestionId;
                var choiceId = ids.ChoiceId;

                var question = await _repository.Question.GetQuestionAsync(surveyId, questionId, trackChanges: false);
                var choice = await _repository.Choice.GetChoiceAsync(questionId, choiceId, trackChanges: false);

                if (choice is null)
                    throw new ChoiceNotFoundException(choiceId);
                if (question is null)
                    throw new QuestionNotFoundException(questionId);

                questionsChoices.Add((question, choice));
            }

            var answers = _mapper.Map<IEnumerable<AnswerForCreationDto>>((questionsChoices));
            var reformattedFilledSurveyForCreation = new FilledSurveyForCreationDto { Answers = answers };
            var fillSurvey = _mapper.Map<FilledSurveyModel>(reformattedFilledSurveyForCreation);

            _repository.FilledSurvey.CreateFilledSurveyForSurvey(surveyId, fillSurvey);
            await _repository.SaveAsync();

            var fillSurveyDto = _mapper.Map<FilledSurveyModelDto>(fillSurvey);

            return fillSurveyDto;

        }

        public async Task<FilledSurveyAnswerDto> GetFilledSurveyAnswersAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);


            var filledSurvey = await _repository.FilledSurvey.GetFilledSurveyAnswersAsync(surveyId, id, trackChanges);
            var filledSurveyDto = _mapper.Map<FilledSurveyAnswerDto>(filledSurvey);

            return filledSurveyDto;
        }

        public async Task<FilledSurveyModelDto> GetFilledSurveyAsync(Guid surveyId, Guid id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);

            var filledSurveyEntity = await _repository.FilledSurvey.GetFilledSurveyAsync(surveyId, id, trackChanges);
            var toReturn = _mapper.Map<FilledSurveyModelDto>(filledSurveyEntity);

            return toReturn;

        }



        public async Task<IEnumerable<FilledSurveyModelDto>> GetFilledSurveysAsync(Guid surveyId, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
                throw new SurveyNotFoundException(surveyId);

            var filledSurveys = await _repository.FilledSurvey.GetFilledSurveysAsync(surveyId, trackChanges);

            var toReturn = _mapper.Map<IEnumerable<FilledSurveyModelDto>>(filledSurveys);

            return toReturn;
        }

        private async Task CheckIfSurveyExists(Guid surveyId, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
                throw new SurveyNotFoundException(surveyId);
        }
    }
}
