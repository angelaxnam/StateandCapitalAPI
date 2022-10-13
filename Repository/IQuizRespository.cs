using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace stateandcapitalapp_api.repository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuiz(long id);
    }
}