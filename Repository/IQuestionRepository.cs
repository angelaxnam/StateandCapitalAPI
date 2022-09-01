using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace stateandcapitalapp_api.repository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
    }
}