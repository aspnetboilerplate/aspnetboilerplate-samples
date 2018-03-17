using System.Collections.Generic;
using System.Linq;
using Volo.SqliteDemo.Roles.Dto;
using Volo.SqliteDemo.Users.Dto;

namespace Volo.SqliteDemo.Web.Models.Users
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
