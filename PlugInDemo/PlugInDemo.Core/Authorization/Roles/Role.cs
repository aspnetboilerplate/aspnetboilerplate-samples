using Abp.Authorization.Roles;
using PlugInDemo.MultiTenancy;
using PlugInDemo.Users;

namespace PlugInDemo.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}