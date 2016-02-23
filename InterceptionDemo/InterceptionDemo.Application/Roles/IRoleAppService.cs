using System.Threading.Tasks;
using Abp.Application.Services;
using InterceptionDemo.Roles.Dto;

namespace InterceptionDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
