using System.Collections.Generic;
using AbpCoreEf7JsonColumnDemo.Roles.Dto;

namespace AbpCoreEf7JsonColumnDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
