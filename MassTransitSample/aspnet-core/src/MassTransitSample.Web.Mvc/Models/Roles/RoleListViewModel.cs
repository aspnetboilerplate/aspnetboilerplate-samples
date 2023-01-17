using System.Collections.Generic;
using MassTransitSample.Roles.Dto;

namespace MassTransitSample.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
