using Application.Aggregates.PaymentMethod.Commands;
using AutoMapper;
using Domain.DTO.PaymentMethod;

namespace Application.Aggregates.PaymentMethod.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePaymentMethod.Command, Domain.Entities.PaymentMethod>(MemberList.Source);
            CreateMap<UpdatePaymentMethod.Command, Domain.Entities.PaymentMethod>(MemberList.Source);

            CreateMap<DeletePaymentMethod.Command, Domain.Entities.PaymentMethod>(MemberList.Source);

            CreateMap<Domain.Entities.PaymentMethod, ListPaymentMethodDTO>(MemberList.Destination);

        }
    }
}