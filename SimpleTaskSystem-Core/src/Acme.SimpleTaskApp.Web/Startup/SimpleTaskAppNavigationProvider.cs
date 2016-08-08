using Abp.Application.Navigation;
using Abp.Localization;

namespace Acme.SimpleTaskApp.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class SimpleTaskAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.TaskList,
                        L("TaskList"),
                        url: "Tasks",
                        icon: "fa fa-tasks"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SimpleTaskAppConsts.LocalizationSourceName);
        }
    }
}
