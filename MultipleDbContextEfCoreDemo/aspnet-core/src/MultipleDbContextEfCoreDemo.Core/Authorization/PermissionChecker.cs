using Abp.Authorization;
using MultipleDbContextEfCoreDemo.Authorization.Roles;
using MultipleDbContextEfCoreDemo.Authorization.Users;

namespace MultipleDbContextEfCoreDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
