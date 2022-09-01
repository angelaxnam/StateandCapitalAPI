using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace stateandcapitalapp_api.repository
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetState();
    }
}