using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Volo.SqliteDemo.Roles.Dto;
using Volo.SqliteDemo.Users.Dto;

namespace Volo.SqliteDemo.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
