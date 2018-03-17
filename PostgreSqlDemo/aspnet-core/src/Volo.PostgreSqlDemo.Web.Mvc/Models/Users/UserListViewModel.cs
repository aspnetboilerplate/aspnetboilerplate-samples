using System.Collections.Generic;
using Volo.PostgreSqlDemo.Roles.Dto;
using Volo.PostgreSqlDemo.Users.Dto;

namespace Volo.PostgreSqlDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
