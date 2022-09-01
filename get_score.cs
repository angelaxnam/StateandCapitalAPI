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
    public class get_score
    {
        private IScoreRepository _scoreRepository;

        public get_score(IScoreRepository scoreRepository)
        {
            this._scoreRepository = scoreRepository;
        }
        [FunctionName("GetScore")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "score")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var score= await this._scoreRepository.GetScore();
                return new OkObjectResult(score);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}









