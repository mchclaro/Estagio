using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.AppointmentPayment;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.AppointmentPayment.Queries
{
    public class DetailsAppointmentPayment
    {
        public class Query : IRequest<StandardResult<DetailsAppointmentPaymentDTO>>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Query,StandardResult<DetailsAppointmentPaymentDTO>>
        {
            private readonly IAppointmentPaymentRepository _appointmentPaymentRepository;
            private readonly IMapper _mapper;

            public Handler(IAppointmentPaymentRepository appointmentPaymentRepository,
                IMapper mapper)
            {
                _appointmentPaymentRepository = appointmentPaymentRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<DetailsAppointmentPaymentDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<DetailsAppointmentPaymentDTO> { };

                var appointmentPayment = await _appointmentPaymentRepository.Read(request.Id);

               if (appointmentPayment == null)
                {
                    result.AddError(Code.NotFound,"Nenhum agendamento encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.AppointmentPayment, DetailsAppointmentPaymentDTO>(appointmentPayment);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}