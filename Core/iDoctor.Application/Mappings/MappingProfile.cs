using AutoMapper;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Domain.Entities;

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
            CreateMap<RegisterPatientDto, User>().ForMember(dest => dest.HashedPassword,
                                                   opt => opt.MapFrom(src => src.Password));
            CreateMap<LoginDto, User>().ForMember(dest => dest.HashedPassword,
                                                    opt => opt.MapFrom(src => src.Password));
            CreateMap<UpdateUserDto, User>().ForMember(dest => dest.HashedPassword,
                                                    opt => opt.MapFrom(src => src.Password));


            CreateMap<Patient, ResultPatientDto>().ForMember(dest => dest.Name,
                                                    opt => opt.MapFrom(src => src.User.Name))
                                                  .ForMember(dest => dest.Surname,
                                                    opt => opt.MapFrom(src => src.User.Surname))
                                                  .ForMember(dest => dest.Email,
                                                    opt => opt.MapFrom(src => src.User.Email))
                                                  .ForMember(dest => dest.Image,
                                                    opt => opt.MapFrom(src => src.User.Image));

            CreateMap<UpdatePatientDto, Patient>()
                                                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
                                                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
                                                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email));



            CreateMap<Doctor, ResultDoctorDto>().ForMember(dest => dest.Name,
                                                    opt => opt.MapFrom(src => src.User.Name))
                                                  .ForMember(dest => dest.Surname,
                                                    opt => opt.MapFrom(src => src.User.Surname))
                                                  .ForMember(dest => dest.Email,
                                                    opt => opt.MapFrom(src => src.User.Email))
                                                   .ForMember(dest => dest.Image,
                                                    opt => opt.MapFrom(src => src.User.Image));

            CreateMap<UpdateDoctorDto, Doctor>()
                                                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
                                                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
                                                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
