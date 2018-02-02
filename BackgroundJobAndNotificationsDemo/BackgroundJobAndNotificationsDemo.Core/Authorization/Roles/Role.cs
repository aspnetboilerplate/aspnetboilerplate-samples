using Abp.Authorization.Roles;
using BackgroundJobAndNotificationsDemo.MultiTenancy;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}