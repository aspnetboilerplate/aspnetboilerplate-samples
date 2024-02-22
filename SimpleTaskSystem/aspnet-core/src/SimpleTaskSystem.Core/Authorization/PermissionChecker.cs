using Abp.Authorization;
using SimpleTaskSystem.Authorization.Roles;
using SimpleTaskSystem.Authorization.Users;

namespace SimpleTaskSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
