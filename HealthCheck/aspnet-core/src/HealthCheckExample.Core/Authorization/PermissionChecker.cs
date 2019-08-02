using Abp.Authorization;
using HealthCheckExample.Authorization.Roles;
using HealthCheckExample.Authorization.Users;

namespace HealthCheckExample.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
