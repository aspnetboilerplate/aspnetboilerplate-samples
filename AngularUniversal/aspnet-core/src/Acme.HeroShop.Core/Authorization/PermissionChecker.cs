using Abp.Authorization;
using Acme.HeroShop.Authorization.Roles;
using Acme.HeroShop.Authorization.Users;

namespace Acme.HeroShop.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
