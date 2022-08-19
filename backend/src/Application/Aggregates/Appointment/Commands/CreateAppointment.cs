using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Appointment.Commands
{
    public class CreateAppointment
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public string Description { get; set; }
            public DateTime DataHeld { get; set; }
            public int Status { get; set; }
            public int EstimateId { get; set; }
            public int ClientId { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IAppointmentRepository appointmentRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    var existsClient = await _appointmentRepository.Exists(request.ClientId);
                    if (!existsClient)
                    {
                        string invalidMedicMessage = "Cliente não está registrado";
                        result.AddError(Code.BadRequest, invalidMedicMessage);
                        return result.GetResult();
                    }

                    var existsEstimate = await _appointmentRepository.Exists(request.EstimateId);
                    if (!existsEstimate)
                    {
                        string invalidMedicMessage = "Orçamento não está registrado";
                        result.AddError(Code.BadRequest, invalidMedicMessage);
                        return result.GetResult();
                    }
                
                    var entity = _mapper.Map<Command, Domain.Entities.Appointment>(request);
                    await _appointmentRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao criar o agendamento.");
                }

                return result.GetResult();
            }
        }
    }
}