using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using stateandcapitalapp_api.context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stateandcapitalapp_api.repository
{
    public class QuizRepository : IQuizRepository
    {
        private PortfolioDbContext _dbContext;

        public QuizRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Quiz>> GetQuiz(long id)
        {
            var quiz = await _dbContext.Quiz.Where(i => i.id == id).ToListAsync();
            return quiz;
        }
    }
}