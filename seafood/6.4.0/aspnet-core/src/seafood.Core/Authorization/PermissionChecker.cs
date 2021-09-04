using Abp.Authorization;
using seafood.Authorization.Roles;
using seafood.Authorization.Users;

namespace seafood.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
