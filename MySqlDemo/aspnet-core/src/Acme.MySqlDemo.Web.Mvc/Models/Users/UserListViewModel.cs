using System.Collections.Generic;
using Acme.MySqlDemo.Roles.Dto;
using Acme.MySqlDemo.Users.Dto;

namespace Acme.MySqlDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
