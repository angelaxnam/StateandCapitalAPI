using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using stateandcapitalapp_api.context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stateandcapitalapp_api.repository
{
    public class StateRepository : IStateRepository
    {
        private PortfolioDbContext _dbContext;

        public StateRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<State>> GetState()
        {
            var state = await this._dbContext.State.Take(100).ToListAsync();
            return state;
        }
    }
}