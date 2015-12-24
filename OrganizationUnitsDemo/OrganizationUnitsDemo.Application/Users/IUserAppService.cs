using System.Threading.Tasks;
using Abp.Application.Services;
using OrganizationUnitsDemo.Users.Dto;

namespace OrganizationUnitsDemo.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}