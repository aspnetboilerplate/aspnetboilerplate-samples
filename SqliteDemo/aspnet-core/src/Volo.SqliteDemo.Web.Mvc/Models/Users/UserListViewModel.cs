using System.Collections.Generic;
using Volo.SqliteDemo.Roles.Dto;
using Volo.SqliteDemo.Users.Dto;

namespace Volo.SqliteDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
