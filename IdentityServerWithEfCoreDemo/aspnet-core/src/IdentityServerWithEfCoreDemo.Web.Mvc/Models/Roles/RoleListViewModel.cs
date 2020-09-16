using System.Collections.Generic;
using IdentityServerWithEfCoreDemo.Roles.Dto;

namespace IdentityServerWithEfCoreDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
