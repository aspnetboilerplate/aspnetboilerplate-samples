using Abp.Authorization;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.Authorization.Users;

namespace Acme.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
