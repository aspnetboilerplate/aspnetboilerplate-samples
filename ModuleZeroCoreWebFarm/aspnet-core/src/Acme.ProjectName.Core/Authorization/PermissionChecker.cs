using Abp.Authorization;
using Acme.ProjectName.Authorization.Roles;
using Acme.ProjectName.Authorization.Users;

namespace Acme.ProjectName.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
