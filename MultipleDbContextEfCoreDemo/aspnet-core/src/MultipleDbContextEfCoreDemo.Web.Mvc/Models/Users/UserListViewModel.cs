using System.Collections.Generic;
using MultipleDbContextEfCoreDemo.Roles.Dto;

namespace MultipleDbContextEfCoreDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
