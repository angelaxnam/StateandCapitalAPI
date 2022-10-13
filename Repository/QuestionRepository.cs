using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using stateandcapitalapp_api.context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stateandcapitalapp_api.repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private PortfolioDbContext _dbContext;

        public QuestionRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var question = await this._dbContext.Question.Take(100).ToListAsync();
            return question;
        }
        public async Task<IEnumerable<QuestionViewTable>> GetQuestionView()
        {
            var questionView = await this._dbContext.QuestionViewTable.Take(100).ToListAsync();
            return questionView;
        }
        public async Task SaveAnswer(QuestionViewTable answers)
        {
            this._dbContext.QuestionViewTable.Add(answers);
            await this._dbContext.SaveChangesAsync();
        }
    }
}