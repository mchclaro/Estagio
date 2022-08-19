using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.src.Application.Aggregates.User.Commands;
using Domain.DTO.User;

namespace backend.src.Application.Aggregates.User.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUser.Command, Domain.Entities.User>(MemberList.Source);

            CreateMap<UpdateUser.Command, Domain.Entities.User>(MemberList.Source);

            CreateMap<Domain.Entities.User, ListUserDTO>(MemberList.Destination)
                //.ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhotoUrl, src => src.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.IsActive, src => src.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role))
                .ForMember(dest => dest.Timetables, src => src.MapFrom(src => src.Timetables.Select(x => new TimetablesDTO
                {
                    Id = x.Id,
                    Start = x.Start,
                    End = x.End,
                    Break = x.Break,
                    DayOfWeek = x.DayOfWeek,
                    UserId = x.UserId
                }).ToList()));

        }
    }
}