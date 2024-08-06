using Abp.AutoMapper;
using MultipleDbContextEfCoreDemo.Roles.Dto;
using MultipleDbContextEfCoreDemo.Web.Models.Common;

namespace MultipleDbContextEfCoreDemo.Web.Models.Roles
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
