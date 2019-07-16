using Abp.Authorization;
using Hotel.Authorization.Roles;
using Hotel.Authorization.Users;

namespace Hotel.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
