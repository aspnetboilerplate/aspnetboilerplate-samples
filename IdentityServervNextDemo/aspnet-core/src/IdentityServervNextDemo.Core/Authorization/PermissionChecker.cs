using Abp.Authorization;
using IdentityServervNextDemo.Authorization.Roles;
using IdentityServervNextDemo.Authorization.Users;

namespace IdentityServervNextDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
