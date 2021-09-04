using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using seafood.Configuration;

namespace seafood.Web.Host.Startup
{
    [DependsOn(
       typeof(seafoodWebCoreModule))]
    public class seafoodWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public seafoodWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(seafoodWebHostModule).GetAssembly());
        }
    }
}
