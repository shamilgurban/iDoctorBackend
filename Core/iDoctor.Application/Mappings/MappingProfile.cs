using AutoMapper;
using iDoctor.Application.Dtos.BloodTypeDtos;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Dtos.GenderDtos;
using iDoctor.Application.Dtos.MaritalStatusDtos;
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

            CreateMap<Gender, ResultGenderDto>();
            CreateMap<CreateGenderDto, Gender>();
            CreateMap<UpdateGenderDto, Gender>();

            CreateMap<MaritalStatus, ResultMaritalStatusDto>();
            CreateMap<CreateMaritalStatusDto, MaritalStatus>();
            CreateMap<UpdateMaritalStatusDto, MaritalStatus>();

            CreateMap<BloodType, ResultBloodTypeDto>();
            CreateMap<CreateBloodTypeDto, BloodType>();
            CreateMap<UpdateBloodTypeDto, BloodType>();

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
                                                    opt => opt.MapFrom(src => src.User.Image))
                                                  .ForMember(dest => dest.Phone,
                                                    opt => opt.MapFrom(src => src.User.Phone))
                                                  .ForMember(dest => dest.Gender,
                                                    opt => opt.MapFrom(src => src.Gender.Name))
                                                  .ForMember(dest => dest.BloodType,
                                                    opt => opt.MapFrom(src => src.BloodType.Type))
                                                  .ForMember(dest => dest.MartialStatus,
                                                    opt => opt.MapFrom(src => src.MaritalStatus.Status));

            CreateMap<UpdatePatientDto, Patient>()
                                                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
                                                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
                                                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
                                                .ForPath(dest => dest.User.Phone, opt => opt.MapFrom(src => src.Phone));



            CreateMap<Doctor, ResultDoctorDto>().ForMember(dest => dest.Name,
                                                    opt => opt.MapFrom(src => src.User.Name))
                                                  .ForMember(dest => dest.Surname,
                                                    opt => opt.MapFrom(src => src.User.Surname))
                                                  .ForMember(dest => dest.Email,
                                                    opt => opt.MapFrom(src => src.User.Email))
                                                   .ForMember(dest => dest.Image,
                                                    opt => opt.MapFrom(src => src.User.Image))
                                                    .ForMember(dest => dest.Phone,
                                                    opt => opt.MapFrom(src => src.User.Phone));

            CreateMap<UpdateDoctorDto, Doctor>()
                                                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
                                                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
                                                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
                                                .ForPath(dest => dest.User.Phone, opt => opt.MapFrom(src => src.Phone));

        }
    }
}
