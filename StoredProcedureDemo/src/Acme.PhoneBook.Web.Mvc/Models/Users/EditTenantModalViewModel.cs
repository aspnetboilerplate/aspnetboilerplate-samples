using System.Collections.Generic;
using System.Linq;
using Acme.PhoneBook.Roles.Dto;
using Acme.PhoneBook.Users.Dto;

namespace Acme.PhoneBook.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.Roles != null && User.Roles.Any(r => r == role.DisplayName);
        }
    }
}