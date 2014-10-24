using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace AbpjTable
{
    [DependsOn(typeof(AbpWebApiModule), typeof(AbpjTableApplicationModule))]
    public class AbpjTableWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(AbpjTableApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
