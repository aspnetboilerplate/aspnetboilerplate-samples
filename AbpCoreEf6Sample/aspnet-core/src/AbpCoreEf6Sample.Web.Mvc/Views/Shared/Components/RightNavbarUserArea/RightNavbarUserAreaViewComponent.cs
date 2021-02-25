using System.Threading.Tasks;
using Abp.Configuration.Startup;
using AbpCoreEf6Sample.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace AbpCoreEf6Sample.Web.Views.Shared.Components.RightNavbarUserArea
{
    public class RightNavbarUserAreaViewComponent : AbpCoreEf6SampleViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public RightNavbarUserAreaViewComponent(
            ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig)
        {
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new RightNavbarUserAreaViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
            };

            return View(model);
        }
    }
}

