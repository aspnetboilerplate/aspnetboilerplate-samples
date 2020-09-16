using System.Collections.Generic;
using IdentityServerWithEfCoreDemo.Roles.Dto;

namespace IdentityServerWithEfCoreDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
