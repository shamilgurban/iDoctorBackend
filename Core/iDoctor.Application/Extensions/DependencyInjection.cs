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
           
            return services;
        }
    }
}
