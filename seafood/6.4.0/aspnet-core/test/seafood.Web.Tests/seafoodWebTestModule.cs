using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using seafood.EntityFrameworkCore;
using seafood.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace seafood.Web.Tests
{
    [DependsOn(
        typeof(seafoodWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class seafoodWebTestModule : AbpModule
    {
        public seafoodWebTestModule(seafoodEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(seafoodWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(seafoodWebMvcModule).Assembly);
        }
    }
}