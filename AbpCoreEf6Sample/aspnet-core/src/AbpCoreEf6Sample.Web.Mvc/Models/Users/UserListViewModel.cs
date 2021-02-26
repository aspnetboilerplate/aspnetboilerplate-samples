using System.Collections.Generic;
using AbpCoreEf6Sample.Roles.Dto;

namespace AbpCoreEf6Sample.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
