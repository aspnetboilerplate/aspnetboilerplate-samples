using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace MultipleDbContextDemo
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MultipleDbContextDemoApplicationModule))]
    public class MultipleDbContextDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MultipleDbContextDemoApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
