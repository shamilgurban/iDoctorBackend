using AutoMapper;
using iDoctor.Application.Dtos.AnalysisDtos;
using iDoctor.Application.Dtos.AppointmentDtos;
using iDoctor.Application.Dtos.BloodTypeDtos;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Dtos.EducationDtos;
using iDoctor.Application.Dtos.GenderDtos;
using iDoctor.Application.Dtos.MaritalStatusDtos;
using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Application.Dtos.SpecialtyDtos;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Application.Helpers.Enums;
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

            CreateMap<Specialty, ResultSpecialtyDto>();
            CreateMap<CreateSpecialtyDto, Specialty>();
            CreateMap<UpdateSpecialtyDto, Specialty>();

            CreateMap<Education, ResultEducationDto>();
            CreateMap<CreateEducationDto, Education>();
            CreateMap<UpdateEducationDto, Education>();

            CreateMap<Analysis, ResultAnalysisDto>();
            CreateMap<CreateAnalysisDto, Analysis>();
            CreateMap<UpdateAnalysisDto, Analysis>();

            CreateMap<User, ResultUserDto>().ForMember(dest => dest.Type,
                                                            opt => opt.MapFrom(src => ((UserTypes)src.Type).ToString()));

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
                                                    opt => opt.MapFrom(src => src.User.Phone))
                                                   .ForMember(dest => dest.SpecialtyName,
                                                    opt => opt.MapFrom(src => src.Specialty.Name))
                                                   .ForMember(dest => dest.VerificationStatus,
                                                    opt => opt.MapFrom(src => ((VerificationStatuses)src.VerificationStatus).ToString()));

            CreateMap<UpdateDoctorDto, Doctor>()
                                                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
                                                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
                                                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
                                                .ForPath(dest => dest.User.Phone, opt => opt.MapFrom(src => src.Phone))
                                                .ForPath(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations));


            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<Appointment, ResultAppointmentDto>().ForMember(dest => dest.PatientFullName,
                                                           opt => opt.MapFrom(src => src.Patient.User.Name + " " + src.Patient.User.Surname))      
                                                         .ForMember(dest => dest.DoctorFullName,
                                                           opt => opt.MapFrom(src => src.Doctor.User.Name + " " + src.Doctor.User.Surname))
                                                         .ForMember(dest => dest.AnalysisName,
                                                           opt => opt.MapFrom(src => src.Analysis.Name))
                                                          .ForMember(dest => dest.Status,
                                                            opt => opt.MapFrom(src => ((AppointmentStatus)src.Status).ToString()));
        }
    }
}
