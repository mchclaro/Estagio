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
    public class UpdateAppointment
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public DateTime DataHeld { get; set; }
            public int Status { get; set; }
            public int EstimateId { get; set; }
            public int ClientId { get; set; }
            public string Service { get; set; }
            public string DescriptionService { get; set; }
            public decimal Value  { get; set; }
            // public int ClientIdService { get; set; }
        }

        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IClientRepository _clientRepository;
            private readonly IEstimateRepository _estimateRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IAppointmentRepository appointmentRepository,
                           IClientRepository clientRepository,
                           IEstimateRepository estimateRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _clientRepository = clientRepository;
                _estimateRepository = estimateRepository;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    if (!await _appointmentRepository.Exists(request.Id))
                    {
                        result.AddError(Code.BadRequest, "Agendamento não encontrado.");
                        return result.GetResult();
                    }

                    var existsClient = await _clientRepository.Exists(request.ClientId);
                    if (!existsClient)
                    {
                        string invalidMedicMessage = "Cliente não está registrado";
                        result.AddError(Code.BadRequest, invalidMedicMessage);
                        return result.GetResult();
                    }
                    
                    var existsEstimate = await _estimateRepository.Exists(request.EstimateId);
                    if (!existsEstimate)
                    {
                        string invalidMedicMessage = "Orçamento não está registrado";
                        result.AddError(Code.BadRequest, invalidMedicMessage);
                        return result.GetResult();
                    }
                
                    var entity = _mapper.Map<Command, Domain.Entities.Appointment>(request);
                    await _appointmentRepository.Update(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao atualizar o agendamento.");
                }

                return result.GetResult();
            }
        }
    }
}