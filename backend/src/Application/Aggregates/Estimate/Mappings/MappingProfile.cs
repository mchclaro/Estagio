using Application.Aggregates.Estimate.Commands;
using AutoMapper;

namespace Application.Aggregates.Estimate.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEstimate.Command, Domain.Entities.Estimate>(MemberList.Source);
        }
    }
}