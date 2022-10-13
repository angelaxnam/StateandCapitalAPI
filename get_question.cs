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
    public class get_question
    {
        private IQuestionRepository _questionRepository;

        public get_question(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }
        [FunctionName("GetQuestions")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "question")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var question = await this._questionRepository.GetQuestions();
                return new OkObjectResult(question);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [FunctionName("GetQuestionView")]
        public async Task<IActionResult> GetQuestionView(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "qview")] HttpRequest req,
           ILogger log)
        {
            try
            {
                var questionView = await this._questionRepository.GetQuestionView();
                return new OkObjectResult(questionView);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
  
        
   






