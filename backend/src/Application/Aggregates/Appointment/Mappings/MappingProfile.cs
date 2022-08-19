using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Appointment.Commands;
using AutoMapper;
using Domain.DTO.Appointment;

namespace Application.Aggregates.Appointment.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAppointment.Command, Domain.Entities.Appointment>(MemberList.Source)
            .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
            .ForMember(dest => dest.DataHeld, src => src.MapFrom(src => src.DataHeld))
            .ForMember(dest => dest.Status, src => src.MapFrom(src => src.Status))
            .ForMember(dest => dest.EstimateId, src => src.MapFrom(src => src.EstimateId))
            .ForMember(dest => dest.ClientId, src => src.MapFrom(src => src.ClientId));

            CreateMap<UpdateAppointment.Command, Domain.Entities.Appointment>(MemberList.Source)
            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
            .ForMember(dest => dest.DataHeld, src => src.MapFrom(src => src.DataHeld))
            .ForMember(dest => dest.Status, src => src.MapFrom(src => src.Status))
            .ForMember(dest => dest.EstimateId, src => src.MapFrom(src => src.EstimateId))
            .ForMember(dest => dest.ClientId, src => src.MapFrom(src => src.ClientId));

            CreateMap<Domain.Entities.Appointment, ListAppointmentDTO>(MemberList.Destination);
        }
    }
}