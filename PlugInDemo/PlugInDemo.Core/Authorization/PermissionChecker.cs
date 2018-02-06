using Abp.Authorization;
using PlugInDemo.Authorization.Roles;
using PlugInDemo.Users;

namespace PlugInDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
