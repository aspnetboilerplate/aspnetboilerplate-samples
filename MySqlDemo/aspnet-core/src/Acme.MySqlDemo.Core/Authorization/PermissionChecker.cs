using Abp.Authorization;
using Acme.MySqlDemo.Authorization.Roles;
using Acme.MySqlDemo.Authorization.Users;

namespace Acme.MySqlDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
