using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using seafood.Authorization;

namespace seafood
{
    [DependsOn(
        typeof(seafoodCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class seafoodApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<seafoodAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(seafoodApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
