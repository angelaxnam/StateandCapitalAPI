using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using stateandcapitalapp_api.context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stateandcapitalapp_api.repository
{
    public class ScoreRepository : IScoreRepository
    {
        private PortfolioDbContext _dbContext;

        public ScoreRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Score>> GetScore()
        {
            var score = await this._dbContext.Score.Take(100).ToListAsync();
            return score;
        }
    }
}