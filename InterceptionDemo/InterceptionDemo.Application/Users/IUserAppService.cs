using System.Threading.Tasks;
using Abp.Application.Services;
using InterceptionDemo.Users.Dto;

namespace InterceptionDemo.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}