using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO.AppointmentPayment;

namespace Application.Aggregates.AppointmentPayment.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Domain.Entities.AppointmentPayment, ListAppointmentPaymentDTO>(MemberList.Destination)
            .ForMember(dest => dest.Number, src => src.MapFrom(src => src.Numbers))
            .ForMember(dest => dest.Sum, src => src.MapFrom(src => src.Value));

            CreateMap<Domain.Entities.AppointmentPayment, DetailsAppointmentPaymentDTO>(MemberList.Destination)
            .ForMember(dest => dest.IsSignal, src => src.MapFrom(src => src.IsSignal))
            .ForMember(dest => dest.DatePayment, src => src.MapFrom(src => src.DatePayment))
            .ForMember(dest => dest.Value, src => src.MapFrom(src => src.Value))
            .ForMember(dest => dest.PaymentStatus, src => src.MapFrom(src => src.PaymentStatus))
            .ForMember(dest => dest.PaymentMethodName, src => src.MapFrom(src => src.PaymentMethod.Name));
        }
    }
}