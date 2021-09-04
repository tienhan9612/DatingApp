using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace seafood.Controllers
{
    public abstract class seafoodControllerBase: AbpController
    {
        protected seafoodControllerBase()
        {
            LocalizationSourceName = seafoodConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
