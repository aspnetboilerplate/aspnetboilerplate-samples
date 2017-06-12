using System.Linq;
using System.Threading.Tasks;
using Abp.Configuration;
using IdentityServerDemo.Configuration;
using IdentityServerDemo.Configuration.Ui;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Views.Shared.Components.RightSideBar
{
    public class RightSideBarViewComponent : ViewComponent
    {
        private readonly ISettingManager _settingManager;

        public RightSideBarViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var themeName = await _settingManager.GetSettingValueAsync(AppSettingNames.UiTheme);

            var viewModel = new RightSideBarViewModel
            {
                CurrentTheme = UiThemes.All.FirstOrDefault(t => t.CssClass == themeName)
            };

            return View(viewModel);
        }
    }
}
