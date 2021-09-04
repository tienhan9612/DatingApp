using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using seafood.Configuration.Dto;

namespace seafood.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : seafoodAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
