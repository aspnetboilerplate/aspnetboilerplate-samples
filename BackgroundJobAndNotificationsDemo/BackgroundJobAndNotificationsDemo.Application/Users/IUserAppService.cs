using System.Threading.Tasks;
using Abp.Application.Services;
using BackgroundJobAndNotificationsDemo.Users.Dto;

namespace BackgroundJobAndNotificationsDemo.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}