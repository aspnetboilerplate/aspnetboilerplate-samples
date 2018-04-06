using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Volo.PostgreSqlDemo.Roles.Dto;

namespace Volo.PostgreSqlDemo.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
