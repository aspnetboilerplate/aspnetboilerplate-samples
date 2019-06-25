using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using Abp.Organizations;
using IdentityServerDemo.Authorization.Roles;

namespace IdentityServerDemo.Authorization.Users
{
    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter, 
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserClaim, long> userCliamRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
            : base(
                unitOfWorkManager,
                userRepository,
                roleRepository,
                asyncQueryableExecuter,
                userRoleRepository,
                userLoginRepository,
                userCliamRepository,
                userPermissionSettingRepository,
                userOrganizationUnitRepository,
                organizationUnitRoleRepository)
        {
        }
    }
}