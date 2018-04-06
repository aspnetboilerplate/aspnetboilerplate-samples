using Abp.Authorization;
using Volo.PostgreSqlDemo.Authorization.Roles;
using Volo.PostgreSqlDemo.Authorization.Users;

namespace Volo.PostgreSqlDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
