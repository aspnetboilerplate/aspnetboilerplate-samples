using System.Collections.Generic;
using IdentityServerWithEfCoreDemo.Roles.Dto;

namespace IdentityServerWithEfCoreDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}