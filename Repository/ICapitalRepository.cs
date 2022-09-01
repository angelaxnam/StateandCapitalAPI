using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace stateandcapitalapp_api.repository
{
    public interface ICapitalRepository
    {
        Task<IEnumerable<Capital>> GetCapitals();
        Task<IEnumerable<Capital>> GetCapital(long id);
    }
}