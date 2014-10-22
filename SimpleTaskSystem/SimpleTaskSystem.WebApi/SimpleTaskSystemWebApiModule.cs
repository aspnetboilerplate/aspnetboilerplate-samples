using System.Reflection;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;

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

            //TODO: Use ForAll!!!

            DynamicApiControllerBuilder
                .For<ITaskAppService>("tasksystem/task")
                .Build();

            DynamicApiControllerBuilder
                .For<IPersonAppService>("tasksystem/person")
                .Build();
        }
    }
}
