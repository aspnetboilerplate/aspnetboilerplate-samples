using System.Collections.Generic;
using HealthCheckExample.Roles.Dto;

namespace HealthCheckExample.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}