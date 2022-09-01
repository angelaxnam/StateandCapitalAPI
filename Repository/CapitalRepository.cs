using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using stateandcapitalapp_api.context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stateandcapitalapp_api.repository
{
    public class CapitalRepository : ICapitalRepository
    {
        private PortfolioDbContext _dbContext;

        public CapitalRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Capital>> GetCapitals()
        {
            var capital = await this._dbContext.Capital.Take(100).ToListAsync();
            return capital;
        }

        public async Task<IEnumerable<Capital>> GetCapital(long id)

        {
              var capital = await _dbContext.Capital.Where(i => i.id == id).ToListAsync();
              return capital;
        }
    }
}

