using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
    internal sealed class ChoiceService : IChoiceService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ChoiceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<ChoiceDto> CreateChoiceForQuestionAsync(Guid surveyId, Guid questionId, ChoiceForCreationDto choiceForCreation, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);
            await CheckIfQuestionExists(surveyId, questionId, trackChanges);

            var choice = _mapper.Map<Choice>(choiceForCreation);
            _repository.Choice.CreateChoiceForQuestion(questionId, choice);
            await _repository.SaveAsync();

            var choiceDto = _mapper.Map<ChoiceDto>(choice);

            return choiceDto;
        }



        public async Task DeleteChoiceForQuestionAsync(Guid surveyId, Guid questionId, int id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);
            await CheckIfQuestionExists(surveyId, questionId, trackChanges);


            var choice = await _repository.Choice.GetChoiceAsync(questionId, id, trackChanges);
            if (choice is null)
                throw new ChoiceNotFoundException(id);
            
            _repository.Choice.DeleteChoice(choice);
            await _repository.SaveAsync();
        }

        public async Task<ChoiceDto> GetChoiceAsync(Guid surveyId, Guid questionId, int id, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);
            await CheckIfQuestionExists(surveyId, questionId, trackChanges);


            var choice = await _repository.Choice.GetChoicesAsync(questionId, trackChanges);
            if (choice is null)
                throw new ChoiceNotFoundException(id);

            var choiceDto = _mapper.Map<ChoiceDto>(choice);

            return choiceDto;
        }

        public async Task<IEnumerable<ChoiceDto>> GetChoicesAsync(Guid surveyId, Guid questionId, bool trackChanges)
        {
            await CheckIfSurveyExists(surveyId, trackChanges);
            await CheckIfQuestionExists(surveyId, questionId, trackChanges);


            var choice = await _repository.Choice.GetChoicesAsync(questionId, trackChanges);

            var choiceToReturn = _mapper.Map<IEnumerable<ChoiceDto>>(choice);

            return choiceToReturn;
        }

        public async Task UpdateChoiceForQuestionAsync(Guid surveyId, Guid questionId, int id, ChoiceForUpdateDto choiceForUpdate, bool questionTrackChanges, bool choiceTrackChanges)
        {
            await CheckIfSurveyExists(surveyId, questionTrackChanges);
            await CheckIfQuestionExists(surveyId, questionId, questionTrackChanges);


            var choice = await _repository.Choice.GetChoicesAsync(questionId, choiceTrackChanges);
            if (choice is null)
                throw new ChoiceNotFoundException(id);

            _mapper.Map(choiceForUpdate, choice);
            await _repository.SaveAsync();

        }

        private async Task CheckIfSurveyExists(Guid surveyId, bool questionTrackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges: questionTrackChanges);
            if (survey is null)
                throw new SurveyNotFoundException(surveyId);
        }

        private async Task CheckIfQuestionExists(Guid surveyId, Guid questionId, bool trackChanges)
        {
            var question = await _repository.Question.GetQuestionAsync(surveyId, questionId, trackChanges);
            if (question is null)
                throw new QuestionNotFoundException(questionId);
        }
    }
}
