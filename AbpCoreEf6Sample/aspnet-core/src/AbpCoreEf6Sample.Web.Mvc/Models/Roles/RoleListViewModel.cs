using System.Collections.Generic;
using AbpCoreEf6Sample.Roles.Dto;

namespace AbpCoreEf6Sample.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
