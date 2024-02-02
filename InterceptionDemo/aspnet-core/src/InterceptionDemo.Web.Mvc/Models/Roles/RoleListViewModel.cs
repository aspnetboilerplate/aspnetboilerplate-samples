using System.Collections.Generic;
using InterceptionDemo.Roles.Dto;

namespace InterceptionDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
