using System.Collections.Generic;
using System.Linq;
using AbpCoreEf7JsonColumnDemo.Roles.Dto;
using AbpCoreEf7JsonColumnDemo.Users.Dto;

namespace AbpCoreEf7JsonColumnDemo.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
