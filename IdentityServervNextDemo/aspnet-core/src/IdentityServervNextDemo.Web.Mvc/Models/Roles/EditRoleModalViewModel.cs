using Abp.AutoMapper;
using IdentityServervNextDemo.Roles.Dto;
using IdentityServervNextDemo.Web.Models.Common;

namespace IdentityServervNextDemo.Web.Models.Roles
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
