using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HealthCheckExample.Roles.Dto;
using HealthCheckExample.Users.Dto;

namespace HealthCheckExample.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
