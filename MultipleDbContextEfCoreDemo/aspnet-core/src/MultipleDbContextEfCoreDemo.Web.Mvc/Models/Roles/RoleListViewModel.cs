using System.Collections.Generic;
using MultipleDbContextEfCoreDemo.Roles.Dto;

namespace MultipleDbContextEfCoreDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
