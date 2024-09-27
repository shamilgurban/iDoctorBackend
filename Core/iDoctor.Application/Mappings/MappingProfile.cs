using AutoMapper;
using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, ResultRoleDto>();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();

            CreateMap<User,ResultUserDto>();
            CreateMap<RegisterDto,User>().ForMember(dest => dest.HashedPassword, 
                                                    opt => opt.MapFrom(src => src.Password));
            CreateMap<LoginDto, User>().ForMember(dest => dest.HashedPassword,
                                                    opt => opt.MapFrom(src => src.Password));
            CreateMap<UpdateUserDto, User>().ForMember(dest => dest.HashedPassword,
                                                    opt => opt.MapFrom(src => src.Password));

        }
    }
}
