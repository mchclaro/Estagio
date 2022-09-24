using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Report.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : BaseController
    {
        /// <summary>
        /// Cria um relatório
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateReport.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }
    }
}