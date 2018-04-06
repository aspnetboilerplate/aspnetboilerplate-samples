using Abp.Authorization;
using AbpKendoDemo.Authorization.Roles;
using AbpKendoDemo.Authorization.Users;

namespace AbpKendoDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
