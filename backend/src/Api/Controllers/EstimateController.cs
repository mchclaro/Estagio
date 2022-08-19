using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Estimate.Commands;
using Application.Aggregates.Estimate.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstimateController : BaseController
    {
        /// <summary>
        /// Cria um orçamento
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateEstimate.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos orçamentos
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListEstimate.Query { }));
        }
    }
}