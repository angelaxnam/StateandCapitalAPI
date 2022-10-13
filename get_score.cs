using System;
using System.Linq;
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
        public async Task<IActionResult> GetScore(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{id}/score")] HttpRequest req,
             long id,
            ILogger log)
        {
            try
            {
                var score = await this._scoreRepository.GetScore(id);
                return new OkObjectResult(score);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [FunctionName("PostScore")]
        public async Task<IActionResult> Run(
         [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "score")] HttpRequest req,
         ILogger log)
        {
            try
            {
                ValidationWrapper<Score> authRequest = await req.GetBodyAsync<Score>();
                if (!authRequest.IsValid)
                {
                    return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", authRequest.ValidationResults.Select(s => s.ErrorMessage).ToArray())}");
                }

                var score = new Score();
                score.id = authRequest.Value.id;
                score.score = authRequest.Value.score; 

                await this._scoreRepository.PostScore(score);

                return new OkObjectResult(score);
            }

            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}









