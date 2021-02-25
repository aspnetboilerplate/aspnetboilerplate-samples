using System.Collections.Generic;
using AbpCoreEf6Sample.Roles.Dto;

namespace AbpCoreEf6Sample.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}