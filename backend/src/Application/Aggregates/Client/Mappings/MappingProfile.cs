using Application.Aggregates.Client.Commands;
using AutoMapper;
using Domain.DTO.Client;
using Domain.Entities;
using Domain.Utils;

namespace Application.Aggregates.Client.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClient.Command, Domain.Entities.Client>(MemberList.Source);
            CreateMap<UpdateClient.Command, Domain.Entities.Client>(MemberList.Source)
            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Address, src => src.MapFrom(src => new Address
            {
                Street = src.AddressStreet,
                StreetNumber = src.AddressStreetNumber,
                District = src.AddressDistrict,
                City = src.AddressCity,
                State = src.AddressState,
                Complement = src.AddressComplement,
                ZipCode = ValidationHelper.RemoveDirtCharsForCep(src.Zipcode)
            }));

            CreateMap<DeleteClient.Command, Domain.Entities.Client>(MemberList.Source);

            CreateMap<Domain.Entities.Client, ListClientDTO>(MemberList.Destination)
               .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
               .ForMember(dest => dest.Address, src => src.MapFrom(src => new AddressDto
               {
                   Street = src.Address.Street,
                   StreetNumber = src.Address.StreetNumber,
                   Complement = src.Address.Complement,
                   District = src.Address.District,
                   City = src.Address.City,
                   State = src.Address.State,
                   ZipCode = src.Address.ZipCode
               }));
        }
    }
}