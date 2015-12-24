using Abp.Authorization;
using OrganizationUnitsDemo.Authorization.Roles;
using OrganizationUnitsDemo.MultiTenancy;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
