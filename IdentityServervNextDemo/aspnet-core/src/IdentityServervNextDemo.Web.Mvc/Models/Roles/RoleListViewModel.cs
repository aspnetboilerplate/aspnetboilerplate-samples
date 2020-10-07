using System.Collections.Generic;
using IdentityServervNextDemo.Roles.Dto;

namespace IdentityServervNextDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
