using System.Threading.Tasks;
using Abp.Application.Services;
using AbpKendoDemo.Roles.Dto;

namespace AbpKendoDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
