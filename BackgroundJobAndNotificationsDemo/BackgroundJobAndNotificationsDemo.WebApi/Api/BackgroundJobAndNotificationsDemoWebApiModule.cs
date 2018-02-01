using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.WebApi;

namespace BackgroundJobAndNotificationsDemo.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(BackgroundJobAndNotificationsDemoApplicationModule))]
    public class BackgroundJobAndNotificationsDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackgroundJobAndNotificationsDemoWebApiModule).GetAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(BackgroundJobAndNotificationsDemoApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
