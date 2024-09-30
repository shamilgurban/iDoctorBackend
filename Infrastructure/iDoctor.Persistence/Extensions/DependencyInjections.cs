using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace iDoctor.Persistence.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
