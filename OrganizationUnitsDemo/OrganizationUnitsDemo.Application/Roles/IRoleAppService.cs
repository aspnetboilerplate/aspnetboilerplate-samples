using System.Threading.Tasks;
using Abp.Application.Services;
using OrganizationUnitsDemo.Roles.Dto;

namespace OrganizationUnitsDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
