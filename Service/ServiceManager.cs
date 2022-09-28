using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<ISurveyService> _surveyService;
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<IChoiceService> _choiceService;
        private readonly Lazy<IFilledSurveyService> _filledSurveyService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserProviderService> _userProviderService;

        
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            _surveyService = new Lazy<ISurveyService>(() => new SurveyService(repositoryManager, logger, mapper));
            _questionService = new Lazy<IQuestionService>(() => new QuestionService(repositoryManager, logger, mapper));
            _choiceService = new Lazy<IChoiceService>(() => new ChoiceService(repositoryManager, logger, mapper));
            _filledSurveyService = new Lazy<IFilledSurveyService>(() => new FilledSurveyService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
            _userProviderService = new Lazy<IUserProviderService>(() => new UserProviderService(httpContext, logger));
        }

        public ISurveyService SurveyService => _surveyService.Value;

        public IChoiceService ChoiceService => _choiceService.Value;

        public IQuestionService QuestionService => _questionService.Value;
        public IFilledSurveyService FilledSurveyService => _filledSurveyService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IUserProviderService UserProviderService => _userProviderService.Value;
    }
}
