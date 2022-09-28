using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ISurveyRepository> _surveyRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IChoiceRepository> _choiceRepository;
        private readonly Lazy<IFilledSurveyRepository> _filledSurveyRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _surveyRepository = new Lazy<ISurveyRepository>(() => new SurveyRepository(repositoryContext));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));
            _choiceRepository = new Lazy<IChoiceRepository>(() => new ChoiceRepository(repositoryContext));
            _filledSurveyRepository = new Lazy<IFilledSurveyRepository>(() => new FilledSurveyRepository(repositoryContext));
        }


        public ISurveyRepository Survey => _surveyRepository.Value;

        public IQuestionRepository Question => _questionRepository.Value;

        public IChoiceRepository Choice => _choiceRepository.Value;
        public IFilledSurveyRepository FilledSurvey => _filledSurveyRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
