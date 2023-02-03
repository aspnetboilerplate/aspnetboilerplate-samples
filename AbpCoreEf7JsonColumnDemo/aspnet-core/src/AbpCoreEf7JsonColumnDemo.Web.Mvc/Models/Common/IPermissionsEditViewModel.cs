using System.Collections.Generic;
using AbpCoreEf7JsonColumnDemo.Roles.Dto;

namespace AbpCoreEf7JsonColumnDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}