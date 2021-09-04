using System.Collections.Generic;
using System.Reflection;
using Ecommerce_App.Models.Infrastructure;
using Ecommerce_App.Models.Infrastructure.Interface;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Ecommerce_App
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
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        } 
              
    }
}