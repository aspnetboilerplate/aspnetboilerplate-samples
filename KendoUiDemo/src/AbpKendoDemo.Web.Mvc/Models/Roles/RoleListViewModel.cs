using System.Collections.Generic;
using AbpKendoDemo.Roles.Dto;

namespace AbpKendoDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
