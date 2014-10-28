using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace SimpleTaskSystem
{
    /// <summary>
    /// 'Web API layer module' for this project.
    /// </summary>
    [DependsOn(typeof(AbpWebApiModule))] //We declare depended modules explicitly
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Creating dynamic Web Api Controllers for application services.
            //Thus, 'web api layer' is created automatically by ABP.

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(Assembly.GetAssembly(typeof (SimpleTaskSystemApplicationModule)), "tasksystem")
                .Build();
        }
    }
}
