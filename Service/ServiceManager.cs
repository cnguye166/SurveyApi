using AutoMapper;
using Contracts;
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

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _surveyService = new Lazy<ISurveyService>(() => new SurveyService(repositoryManager, logger, mapper));
            _questionService = new Lazy<IQuestionService>(() => new QuestionService(repositoryManager, logger, mapper));
            _choiceService = new Lazy<IChoiceService>(() => new ChoiceService(repositoryManager, logger, mapper));

        }

        public ISurveyService SurveyService => _surveyService.Value;

        public IChoiceService ChoiceService => _choiceService.Value;

        public IQuestionService QuestionService => _questionService.Value;
    }
}
