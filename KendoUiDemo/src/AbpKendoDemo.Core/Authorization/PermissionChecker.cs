using Abp.Authorization;
using AbpKendoDemo.Authorization.Roles;
using AbpKendoDemo.MultiTenancy;
using AbpKendoDemo.Users;

namespace AbpKendoDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
