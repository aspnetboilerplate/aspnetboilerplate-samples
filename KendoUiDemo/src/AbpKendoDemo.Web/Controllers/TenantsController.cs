using Abp.AspNetCore.Mvc.Authorization;
using AbpKendoDemo.Authorization;
using AbpKendoDemo.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace AbpKendoDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : AbpKendoDemoControllerBase
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