using Application.Aggregates.Estimate.Commands;
using AutoMapper;
using Domain.DTO.Estimate;

namespace Application.Aggregates.Estimate.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEstimate.Command, Domain.Entities.Estimate>(MemberList.Source);

            CreateMap<Domain.Entities.Estimate, ListEstimateDTO>(MemberList.Destination)
            .ForMember(dest => dest.Service, src => src.MapFrom(src => src.Service))
            .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
            .ForMember(dest => dest.Value, src => src.MapFrom(src => src.Value))
            .ForMember(dest => dest.CreatedDate, src => src.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ValidateDate, src => src.MapFrom(src => src.ValidateDate))
            .ForMember(dest => dest.Client, src => src.MapFrom(src => new ClientDto
            {
                Name = src.Client.Name
            }));
        }
    }
}