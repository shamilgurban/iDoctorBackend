using iDoctor.Application.Services;
using iDoctor.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace iDoctor.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IMaritalStatusService, MaritalStatusService>();
            services.AddScoped<IBloodTypeService, BloodTypeService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IAnalysisService, AnalysisService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
