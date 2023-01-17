using System.Collections.Generic;
using MassTransitSample.Roles.Dto;

namespace MassTransitSample.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
