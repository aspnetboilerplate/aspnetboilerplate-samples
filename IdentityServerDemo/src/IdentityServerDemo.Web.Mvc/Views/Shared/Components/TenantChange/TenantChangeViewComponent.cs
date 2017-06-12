using System.Threading.Tasks;
using Abp.AutoMapper;
using IdentityServerDemo.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public TenantChangeViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = loginInfo.MapTo<TenantChangeViewModel>();
            return View(model);
        }
    }
}
