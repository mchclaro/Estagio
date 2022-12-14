using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Appointment.Commands;
using Application.Aggregates.Appointment.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : BaseController
    {
        /// <summary>
        /// Cria um agendamento
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAppointment.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAppointment.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos agendamentos
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListAppointment.Query { }));
        }

        /// <summary>
        /// Busca um agendamento por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsAppointment.Query { Id = id }));
        }

        /// <summary>
        /// Gera um relatório diário
        /// </summary>
        [HttpGet("report/daily")]
        public async Task<IActionResult> DailyReport()
        {
            return GetIActionResult(await Mediator.Send(new DailyReport.Query { }));
        }

        /// <summary>
        /// Gera um relatório dos últimos 7 dias
        /// </summary>
        [HttpGet("report/weekly")]
        public async Task<IActionResult> WeeklyReport()
        {
            return GetIActionResult(await Mediator.Send(new WeeklyReport.Query { }));
        }
        
        /// <summary>
        /// Gera um relatório do mês
        /// </summary>
        [HttpGet("report/month")]
        public async Task<IActionResult> MonthReport()
        {
            return GetIActionResult(await Mediator.Send(new MonthReport.Query { }));
        }
    }
}