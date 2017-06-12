using Abp.AspNetCore.Mvc.Authorization;
using IdentityServerDemo.Authorization;
using IdentityServerDemo.Controllers;
using IdentityServerDemo.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : IdentityServerDemoControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}