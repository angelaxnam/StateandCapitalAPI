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
    public class get_capital
    {
        private ICapitalRepository _capitalRepository;

        public get_capital(ICapitalRepository capitalRepository)
        {
            this._capitalRepository = capitalRepository;
        }
        [FunctionName("GetCapitals")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "potato")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var capital = await this._capitalRepository.GetCapitals();
                return new OkObjectResult(capital);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }


        [FunctionName("GetCapital")]
        public async Task<IActionResult> GetCompetency(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "capital/{id}")] HttpRequest req,
                long id,
                ILogger log)
        {
            try
            {
                var capital = await this._capitalRepository.GetCapital(id);
                return new OkObjectResult(capital);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
    


    

