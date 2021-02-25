using System.Collections.Generic;
using System.Linq;
using AbpCoreEf6Sample.Roles.Dto;
using AbpCoreEf6Sample.Users.Dto;

namespace AbpCoreEf6Sample.Web.Models.Users
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
