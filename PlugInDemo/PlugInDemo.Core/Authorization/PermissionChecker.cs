using Abp.Authorization;
using PlugInDemo.Authorization.Roles;
using PlugInDemo.MultiTenancy;
using PlugInDemo.Users;

namespace PlugInDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
