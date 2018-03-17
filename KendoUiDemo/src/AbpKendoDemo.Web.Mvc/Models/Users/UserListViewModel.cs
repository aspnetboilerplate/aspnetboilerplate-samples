using System.Collections.Generic;
using AbpKendoDemo.Roles.Dto;
using AbpKendoDemo.Users.Dto;

namespace AbpKendoDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
