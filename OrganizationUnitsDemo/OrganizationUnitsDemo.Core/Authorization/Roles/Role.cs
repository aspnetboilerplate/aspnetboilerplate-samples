using Abp.Authorization.Roles;
using OrganizationUnitsDemo.MultiTenancy;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}