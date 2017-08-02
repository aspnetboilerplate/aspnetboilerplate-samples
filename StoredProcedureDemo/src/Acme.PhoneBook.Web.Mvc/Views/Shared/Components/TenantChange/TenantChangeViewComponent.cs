using System.Threading.Tasks;
using Abp.AutoMapper;
using Acme.PhoneBook.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace Acme.PhoneBook.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : PhoneBookViewComponent
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
