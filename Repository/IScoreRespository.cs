using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace stateandcapitalapp_api.repository
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> GetScore();
    }
}