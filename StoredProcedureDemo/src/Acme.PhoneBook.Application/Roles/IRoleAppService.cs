using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.PhoneBook.Roles.Dto;

namespace Acme.PhoneBook.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
