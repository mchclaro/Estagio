using Application.Aggregates.Report.Commands;
using AutoMapper;

namespace Application.Aggregates.Report.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReport.Command, Domain.Entities.Report>(MemberList.Source);
        }
    }
}