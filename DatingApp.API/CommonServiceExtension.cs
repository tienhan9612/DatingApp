using System.Reflection;
using DatingApp.API.Infracstructure;
using DatingApp.API.Infracstructure.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace DatingApp.API
{
    public static class CommonServiceExtension
    {
        public static void ConfigureServicesByAssembly(this IServiceCollection services, Assembly assembly)
        {
            services.RegisterAssemblyPublicNonGenericClasses(assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(assembly)
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces();
        
        }

        public static void ConfigureCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

        }
        
    }
}