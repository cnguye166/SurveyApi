using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ISurveyService SurveyService { get; }
        IChoiceService ChoiceService { get; }
        IQuestionService QuestionService { get; }
        IFilledSurveyService FilledSurveyService { get; }
        IAuthenticationService AuthenticationService { get; }
        IUserProviderService UserProviderService { get; }
    }
}
