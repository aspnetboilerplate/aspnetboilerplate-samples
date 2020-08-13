using System.Collections.Generic;
using IdentityServervNextDemo.Roles.Dto;

namespace IdentityServervNextDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
