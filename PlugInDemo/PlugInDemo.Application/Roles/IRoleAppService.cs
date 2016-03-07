using System.Threading.Tasks;
using Abp.Application.Services;
using PlugInDemo.Roles.Dto;

namespace PlugInDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
