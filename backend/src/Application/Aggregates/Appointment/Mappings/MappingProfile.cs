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
            .ForMember(dest => dest.Estimate, src => src.MapFrom(src => new Domain.Entities.Estimate
            {
                Service = src.Service,
                Description = src.DescriptionService,
                Value = src.Value,
                ClientId = src.ClientId
            }));

            CreateMap<Domain.Entities.Appointment, ListAppointmentDTO>(MemberList.Destination)
            .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
            .ForMember(dest => dest.DataHeld, src => src.MapFrom(src => src.DataHeld))
            .ForMember(dest => dest.Status, src => src.MapFrom(src => src.Status))
            .ForMember(dest => dest.Estimate, src => src.MapFrom(src => new ListAppointmentDTO.EstimateDTO
            {
                Service = src.Estimate.Service,
                Description = src.Estimate.Description,
                Value = src.Estimate.Value,
                ValidateDate= src.Estimate.ValidateDate
            }))
            .ForMember(dest => dest.Client, src => src.MapFrom(src => new ListAppointmentDTO.ClientDTO
            {
                Name = src.Client.Name,
                PhotoUrl = src.Client.PhotoUrl,
                Phone = src.Client.Phone
            }))
            .ForMember(dest => dest.AppointmentPayments, src => src.MapFrom(src => src.AppointmentPayments.Select(x => new ListAppointmentDTO.AppointmentPaymentDTO
            {
                IsSignal = x.IsSignal,
                DatePayment = x.DatePayment,
                Value = x.Value,
                PaymentStatus = x.PaymentStatus,
                PaymentMethodName = x.PaymentMethod.Name
            }).ToList()));
        }
    }
}