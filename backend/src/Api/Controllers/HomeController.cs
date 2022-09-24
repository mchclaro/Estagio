using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Client.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Cria um cliente para teste da foto no s3
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateClient.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }
    }
}