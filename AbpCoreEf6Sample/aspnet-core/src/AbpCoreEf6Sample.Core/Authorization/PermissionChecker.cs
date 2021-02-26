using Abp.Authorization;
using AbpCoreEf6Sample.Authorization.Roles;
using AbpCoreEf6Sample.Authorization.Users;

namespace AbpCoreEf6Sample.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
