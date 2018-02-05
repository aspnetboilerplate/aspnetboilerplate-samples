using System.Collections.Generic;
using Acme.MySqlDemo.Roles.Dto;

namespace Acme.MySqlDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
