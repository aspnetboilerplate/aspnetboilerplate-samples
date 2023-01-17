using System.Linq;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitSample.Web.Views.Shared.Components.RightNavbarLanguageSwitch
{
    public class RightNavbarLanguageSwitchViewComponent : MassTransitSampleViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public RightNavbarLanguageSwitchViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public IViewComponentResult Invoke()
        {
            var model = new RightNavbarLanguageSwitchViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages().Where(l => !l.IsDisabled).ToList()
            };

            return View(model);
        }
    }
}
