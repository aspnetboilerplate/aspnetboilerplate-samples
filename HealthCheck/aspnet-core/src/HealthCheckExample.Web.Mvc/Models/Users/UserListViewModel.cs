using System.Collections.Generic;
using HealthCheckExample.Roles.Dto;
using HealthCheckExample.Users.Dto;

namespace HealthCheckExample.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
