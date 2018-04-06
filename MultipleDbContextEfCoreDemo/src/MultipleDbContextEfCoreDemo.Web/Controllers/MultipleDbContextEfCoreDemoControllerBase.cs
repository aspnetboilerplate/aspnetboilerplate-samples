using Abp.AspNetCore.Mvc.Controllers;

namespace MultipleDbContextEfCoreDemo.Web.Controllers
{
    public abstract class MultipleDbContextEfCoreDemoControllerBase: AbpController
    {
        protected MultipleDbContextEfCoreDemoControllerBase()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}