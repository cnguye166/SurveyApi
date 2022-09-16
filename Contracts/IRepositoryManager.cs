using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ISurveyRepository Survey { get; }
        IQuestionRepository Question { get; }
        IChoiceRepository Choice { get; }
        Task SaveAsync();
    }
}
