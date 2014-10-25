using Abp.Application.Navigation;
using Abp.Localization;

namespace AbpjTable.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class AbpjTableNavigationProvider : INavigationProvider
    {
        public void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "People",
                        new LocalizableString("People", AbpjTableConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-users"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Cities",
                        new LocalizableString("Cities", AbpjTableConsts.LocalizationSourceName),
                        url: "#/cities",
                        icon: "fa fa-building-o"
                        )
                );
        }
    }
}
