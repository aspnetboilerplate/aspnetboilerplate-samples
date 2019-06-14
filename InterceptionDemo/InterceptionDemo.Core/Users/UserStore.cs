using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using InterceptionDemo.Authorization.Roles;

namespace InterceptionDemo.Users
{
    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(
            IRepository<User, long> userRepository, 
            IRepository<UserLogin, long> userLoginRepository, 
            IRepository<UserRole, long> userRoleRepository, 
            IRepository<Role> roleRepository, 
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository, 
            IUnitOfWorkManager unitOfWorkManager, 
            IRepository<UserClaim, long> userClaimRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository) : base(
                userRepository, 
                userLoginRepository, 
                userRoleRepository, 
                roleRepository, 
                userPermissionSettingRepository, 
                unitOfWorkManager, 
                userClaimRepository,
                userOrganizationUnitRepository,
                organizationUnitRoleRepository)
        {
        }
    }
}