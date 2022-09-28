using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class SurveyService : ISurveyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;



        public SurveyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<SurveyDto> CreateSurveyAsync(string userId, SurveyForCreationDto survey)
        {
            
            var surveyEntity = _mapper.Map<SurveyModel>((userId, survey));

            _repository.Survey.CreateSurvey(surveyEntity);
            await _repository.SaveAsync();

            var surveyDto = _mapper.Map<SurveyDto>(surveyEntity);
            return surveyDto;
        }

        public async Task DeleteSurveyAsync(Guid surveyId, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);

            if (survey is null)
                throw new SurveyNotFoundException(surveyId);

            _repository.Survey.DeleteSurvey(survey);
            await _repository.SaveAsync();


        }


        public async Task<SurveyQuestionDto> GetSurveyQuestionsChoicesAsync(Guid surveyId, bool trackChanges)
        {
            var surveyEntire = await _repository.Survey.GetSurveyQuestionsChoicesAsync(surveyId, trackChanges);
            if (surveyEntire is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var SurveyQuestionDto = _mapper.Map<SurveyQuestionDto>(surveyEntire);
            return SurveyQuestionDto;
        }

        public async Task<(IEnumerable<SurveyDto> surveys, MetaData metaData)> GetAllSurveysAsync(SurveyParameters surveyParameters, bool trackChanges)
        {

            var surveys = await _repository.Survey.GetAllSurveysAsync(surveyParameters, trackChanges);
            var surveysDto = _mapper.Map<IEnumerable<SurveyDto>>(surveys);

            return (surveysDto, surveys.MetaData);
            
           
        }

        public async Task<SurveyDto> GetSurveyAsync(Guid surveyId, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);
            if (survey is null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var surveyDto = _mapper.Map<SurveyDto>(survey);
            return surveyDto;
        }

        public async Task UpdateSurveyAsync(Guid surveyId, SurveyForUpdateDto surveyForUpdate, bool trackChanges)
        {
            var survey = await _repository.Survey.GetSurveyAsync(surveyId, trackChanges);

            if (survey is null)
                throw new SurveyNotFoundException(surveyId);

            _mapper.Map(surveyForUpdate, survey);
            await _repository.SaveAsync();




        }

        public async Task<IEnumerable<SurveyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var surveyEntities = await _repository.Survey.GetByIdsAsync(ids, trackChanges);

            if(surveyEntities is null)
                throw new CollectionByIdsBadRequestException();

            var surveyEntitiesToReturn = _mapper.Map<IEnumerable<SurveyDto>>(surveyEntities);

            return surveyEntitiesToReturn;

        }
        public async Task<(IEnumerable<SurveyDto> surveys, string ids)> CreateSurveyCollectionAsync(IEnumerable<SurveyForCreationDto> surveyCollection)
        {
            if (surveyCollection is null)
                throw new SurveyCollectionBadRequest();

            var surveyEntities = _mapper.Map<IEnumerable<SurveyModel>>(surveyCollection);

            foreach (var survey in surveyEntities)
            {
                _repository.Survey.CreateSurvey(survey);
            }
            await _repository.SaveAsync();

            var surveyEntitiesToReturn = _mapper.Map<IEnumerable<SurveyDto>>(surveyEntities);
            var ids = string.Join(",", surveyEntitiesToReturn.Select(s => s.Id));

            return (surveys: surveyEntitiesToReturn, ids: ids);
        }
    }
}
