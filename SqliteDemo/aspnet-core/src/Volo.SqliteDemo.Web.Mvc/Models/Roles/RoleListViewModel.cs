using System.Collections.Generic;
using Volo.SqliteDemo.Roles.Dto;

namespace Volo.SqliteDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
