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
            
            CreateMap<Domain.Entities.Estimate, ListEstimateDTO>(MemberList.Destination);
        }
    }
}