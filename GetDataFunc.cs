using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using Teamone.FunctionApp.Commands;

namespace Teamone.FunctionApp
{
    public  class GetDataFunc
    {
        private readonly IMediator _mediator;

        public GetDataFunc(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("Query-Ping")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var result = await _mediator.Send(new Ping { 
                    Message = req.Query["msg"]
                });

                return new OkObjectResult(result);
            } 
            catch(ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }            
        }
    }
}
