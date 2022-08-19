using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Appointment;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.Appointment.Queries
{
    public class DetailsAppointment
    {
        public class Query : IRequest<StandardResult<ListAppointmentDTO>>
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query,StandardResult<ListAppointmentDTO>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public Handler(IAppointmentRepository appointmentRepository,
                IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListAppointmentDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListAppointmentDTO>();

                var appointment = await _appointmentRepository.Read(request.Id);

                if (appointment == null)
                {
                    result.AddError(Code.NotFound,"Nenhum agendamento encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.Appointment, ListAppointmentDTO>(appointment);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}