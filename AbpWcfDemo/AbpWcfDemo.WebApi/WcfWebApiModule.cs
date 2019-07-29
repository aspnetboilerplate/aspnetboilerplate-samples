using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace AbpWcfDemo
{
    [DependsOn(typeof(AbpWebApiModule), typeof(WcfApplicationModule))]
    public class WcfWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(WcfApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
