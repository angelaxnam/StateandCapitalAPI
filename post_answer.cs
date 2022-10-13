using System;
using System.Linq;
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
    public class post_answer
    {
        private IQuestionRepository _questionRepository;

        public post_answer(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }
        [FunctionName("post_answer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "answer")] HttpRequest req,
            ILogger log)
        {
            try
            {
                ValidationWrapper<QuestionViewTable> addAnswerRequest = await req.GetBodyAsync<QuestionViewTable>();
                if (!addAnswerRequest.IsValid)
                {
                    return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", addAnswerRequest.ValidationResults.Select(s => s.ErrorMessage).ToArray())}");
                }

                await this._questionRepository.SaveAnswer(addAnswerRequest.Value);

                return new OkResult();

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}










