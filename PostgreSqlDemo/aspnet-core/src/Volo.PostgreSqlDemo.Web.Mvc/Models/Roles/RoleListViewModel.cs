using System.Collections.Generic;
using Volo.PostgreSqlDemo.Roles.Dto;

namespace Volo.PostgreSqlDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
