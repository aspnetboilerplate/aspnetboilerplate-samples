using System.Collections.Generic;
using InterceptionDemo.Roles.Dto;

namespace InterceptionDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}