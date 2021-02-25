using Abp.AutoMapper;
using AbpCoreEf6Sample.Roles.Dto;
using AbpCoreEf6Sample.Web.Models.Common;

namespace AbpCoreEf6Sample.Web.Models.Roles
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
