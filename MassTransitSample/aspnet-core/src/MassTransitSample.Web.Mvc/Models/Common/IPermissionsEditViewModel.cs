using System.Collections.Generic;
using MassTransitSample.Roles.Dto;

namespace MassTransitSample.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}