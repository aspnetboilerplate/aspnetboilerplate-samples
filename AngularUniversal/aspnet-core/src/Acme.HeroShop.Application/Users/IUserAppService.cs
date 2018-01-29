using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.HeroShop.Roles.Dto;
using Acme.HeroShop.Users.Dto;

namespace Acme.HeroShop.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
