using System.Collections.Generic;
using AbpCoreEf7JsonColumnDemo.Roles.Dto;

namespace AbpCoreEf7JsonColumnDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
