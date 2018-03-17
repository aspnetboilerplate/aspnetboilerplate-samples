using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.ProjectName.Roles.Dto;

namespace Acme.ProjectName.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
