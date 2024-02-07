using System.Collections.Generic;
using InterceptionDemo.Roles.Dto;

namespace InterceptionDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
