using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Npgsql;
using stateandcapitalapp_api.repository;

namespace stateandcapitalapp_api
{
    public class get_quiz
    {
        private IQuizRepository _quizRepository;

        public get_quiz(IQuizRepository quizRepository)
        {
            this._quizRepository = quizRepository;
        }
        [FunctionName("GetQuiz")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test/quiz/{id}")] HttpRequest req,
             long id,
            ILogger log)
        {
            try
            {
                var score= await this._quizRepository.GetQuiz(id);
                return new OkObjectResult(score);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}









