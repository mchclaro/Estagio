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
            CreateMap<CreateUser.Command, Domain.Entities.User>(MemberList.Source);

            CreateMap<UpdateUser.Command, Domain.Entities.User>(MemberList.Source)
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role));

            CreateMap<Domain.Entities.User, ListUserDTO>(MemberList.Destination)
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role));

        }
    }
}