using Abp.Authorization;
using MassTransitSample.Authorization.Roles;
using MassTransitSample.Authorization.Users;

namespace MassTransitSample.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
