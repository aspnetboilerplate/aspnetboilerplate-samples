using System.Threading.Tasks;
using Abp.Application.Services;
using BackgroundJobAndNotificationsDemo.Roles.Dto;

namespace BackgroundJobAndNotificationsDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
