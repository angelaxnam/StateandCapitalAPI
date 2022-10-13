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
        public async Task<IEnumerable<Score>> GetScore(long id)
        {
            var score = await _dbContext.Score.Where(i => i.id == id).ToListAsync();
            return score;
        }
         public async Task PostScore(Score score)
        {
            _dbContext.Score.AddRange(score);
            await _dbContext.SaveChangesAsync();
        }
    }
}