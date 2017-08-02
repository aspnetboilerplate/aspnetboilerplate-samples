using System.Collections.Generic;
using Acme.PhoneBook.Roles.Dto;
using Acme.PhoneBook.Users.Dto;

namespace Acme.PhoneBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}