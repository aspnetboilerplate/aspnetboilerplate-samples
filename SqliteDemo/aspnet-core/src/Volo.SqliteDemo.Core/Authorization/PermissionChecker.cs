using Abp.Authorization;
using Volo.SqliteDemo.Authorization.Roles;
using Volo.SqliteDemo.Authorization.Users;

namespace Volo.SqliteDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
