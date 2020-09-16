using Abp.AutoMapper;
using IdentityServerWithEfCoreDemo.Roles.Dto;
using IdentityServerWithEfCoreDemo.Web.Models.Common;

namespace IdentityServerWithEfCoreDemo.Web.Models.Roles
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
