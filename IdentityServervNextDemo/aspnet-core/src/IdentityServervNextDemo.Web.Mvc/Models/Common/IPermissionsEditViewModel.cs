using System.Collections.Generic;
using IdentityServervNextDemo.Roles.Dto;

namespace IdentityServervNextDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}