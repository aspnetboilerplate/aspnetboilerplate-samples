using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Volo.PostgreSqlDemo.Roles.Dto;
using Volo.PostgreSqlDemo.Users.Dto;

namespace Volo.PostgreSqlDemo.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
