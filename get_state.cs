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
    public class get_state
    {
        private IStateRepository _stateRepository;

        public get_state(IStateRepository stateRepository)
        {
            this._stateRepository = stateRepository;
        }
        [FunctionName("GetState")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "state")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var state = await this._stateRepository.GetState();
                return new OkObjectResult(state);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}









