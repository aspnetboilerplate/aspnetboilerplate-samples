using Abp.Authorization;
using AbpCoreEf7JsonColumnDemo.Authorization.Roles;
using AbpCoreEf7JsonColumnDemo.Authorization.Users;

namespace AbpCoreEf7JsonColumnDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
