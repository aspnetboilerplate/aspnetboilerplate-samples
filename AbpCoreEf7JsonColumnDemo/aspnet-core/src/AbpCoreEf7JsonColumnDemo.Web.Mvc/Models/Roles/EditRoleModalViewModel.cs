using Abp.AutoMapper;
using AbpCoreEf7JsonColumnDemo.Roles.Dto;
using AbpCoreEf7JsonColumnDemo.Web.Models.Common;

namespace AbpCoreEf7JsonColumnDemo.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
