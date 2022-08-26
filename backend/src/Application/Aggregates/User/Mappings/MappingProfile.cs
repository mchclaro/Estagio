using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.src.Application.Aggregates.User.Commands;
using Domain.DTO.User;
using Domain.Entities;

namespace backend.src.Application.Aggregates.User.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUser.Command, Domain.Entities.User>(MemberList.Source)
                .ForMember(dest => dest.Timetable, src => src.Ignore());

            CreateMap<UpdateUser.Command, Domain.Entities.User>(MemberList.Source)
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhotoUrl, src => src.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role))
                .ForMember(dest => dest.Timetable, src => src.MapFrom(src => new Timetable
                {
                    Id = src.Id,
                    Start = src.Start,
                    End = src.End,
                    Break = src.Break,
                    DayOfWeek = src.DayOfWeek
                }));
                
            CreateMap<Domain.Entities.User, ListUserDTO>(MemberList.Destination)
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
                    DayOfWeek = x.DayOfWeek
                }).ToList()));

        }
    }
}