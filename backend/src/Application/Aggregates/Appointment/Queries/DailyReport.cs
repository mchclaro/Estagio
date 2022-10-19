using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Appointment;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Appointment.Queries
{
    public class DailyReport
    {
        public class Query : IRequest<StandardResult<List<ListAppointmentDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListAppointmentDTO>>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public Handler(IAppointmentRepository appointmentRepository,
                IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListAppointmentDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListAppointmentDTO>> { };

                var appointmentList = await _appointmentRepository.DailyReport();

                var responseData = appointmentList.Select(x => _mapper.Map<Domain.Entities.Appointment, ListAppointmentDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}