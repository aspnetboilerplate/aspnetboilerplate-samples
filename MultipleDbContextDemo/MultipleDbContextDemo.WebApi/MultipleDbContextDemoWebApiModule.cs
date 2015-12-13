using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace MultipleDbContextDemo
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MultipleDbContextDemoApplicationModule))]
    public class MultipleDbContextDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MultipleDbContextDemoApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
