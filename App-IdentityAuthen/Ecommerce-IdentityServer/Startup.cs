using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ecommerce_IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var secretKey = Configuration.GetSection("AppSettings:Token").Value;

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(CommonServiceExtension.GetApis())
                    .AddInMemoryApiScopes(CommonServiceExtension.ApiScopes())
                    .AddInMemoryClients(CommonServiceExtension.GetClients(secretKey))
                    .AddTestUsers(CommonServiceExtension.GetUsers())                    
                    // Configuration store: clients and resources
                    .AddConfigurationStore(option =>
                    {
                        option.ConfigureDbContext = b =>
                            b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
                    })
                    // Operation store: tokens, consents, code, etc
                    .AddOperationalStore(option => {
                         option.ConfigureDbContext = b =>
                            b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
                    });

            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
 
            app.UseRouting();
            app.UseIdentityServer();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
