using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.PhoneBook.Authorization.Users.Dtos;
using Acme.PhoneBook.EntityFrameworkCore.Repositories;
using Acme.PhoneBook.Roles.Dto;
using Acme.PhoneBook.Users.Dto;

namespace Acme.PhoneBook.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<List<string>> GetUsers();

        Task<List<string>> GetAdminUsernames();

        Task DeleteUser(EntityDto input);

        Task UpdateEmail(UpdateEmailDto input);

        Task<GetUserByIdOutput> GetUserById(EntityDto input);
    }
}