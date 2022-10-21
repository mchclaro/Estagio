using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.AppointmentPayment.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentPaymentController : BaseController
    {
        /// <summary>
        /// Busca um pagamento de agendamento por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsAppointmentPayment.Query { Id = id }));
        }

        /// <summary>
        /// consultar os agendamentos concluidos
        /// </summary>
        [HttpGet("balance/concluded")]
        public async Task<IActionResult> CheckBalanceConcluded()
        {
            return GetIActionResult(await Mediator.Send(new CheckBalanceConcluded.Query { }));
        }

        /// <summary>
        /// consultar os agendamentos pendentes
        /// </summary>
        [HttpGet("balance/pending")]
        public async Task<IActionResult> CheckBalancePending()
        {
            return GetIActionResult(await Mediator.Send(new CheckBalancePending.Query { }));
        }
    }
}