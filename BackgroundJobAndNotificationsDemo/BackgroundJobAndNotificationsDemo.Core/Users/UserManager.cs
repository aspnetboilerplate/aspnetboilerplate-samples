using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using BackgroundJobAndNotificationsDemo.Authorization.Roles;

namespace BackgroundJobAndNotificationsDemo.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            AbpUserStore<Role, User> userStore, 
            AbpRoleManager<Role, User> roleManager, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings, 
            ILocalizationManager localizationManager, 
            IdentityEmailMessageService emailService, 
            IUserTokenProviderAccessor userTokenProviderAccessor
            )
            : base(
                userStore,
                roleManager,
                permissionManager,
                unitOfWorkManager,
                cacheManager,
                organizationUnitRepository,
                userOrganizationUnitRepository,
                organizationUnitSettings,
                localizationManager,
                emailService,
                settingManager,
                userTokenProviderAccessor)
        {
        }
    }
}