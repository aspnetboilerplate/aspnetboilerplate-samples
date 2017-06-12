using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServerDemo.Roles.Dto;

namespace IdentityServerDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
