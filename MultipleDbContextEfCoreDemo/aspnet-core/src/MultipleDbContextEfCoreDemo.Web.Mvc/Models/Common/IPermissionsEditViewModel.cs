using System.Collections.Generic;
using MultipleDbContextEfCoreDemo.Roles.Dto;

namespace MultipleDbContextEfCoreDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}