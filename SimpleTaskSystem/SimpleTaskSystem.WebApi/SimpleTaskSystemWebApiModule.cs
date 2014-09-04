using System;
using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Abp.WebApi.Startup;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem
{
    /// <summary>
    /// 'Web API layer module' for this project.
    /// </summary>
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
        /// <summary>
        /// We declare depended modules explicitly.
        /// </summary>
        public override Type[] GetDependedModules()
        {
            return new[]
                   {
                       typeof(AbpWebApiModule)
                   };
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);

            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Creating dynamic Web Api Controllers for application services.
            //Thus, 'web api layer' is created automatically by ABP.

            DynamicApiControllerBuilder
                .For<ITaskAppService>("tasksystem/task")
                .Build();

            DynamicApiControllerBuilder
                .For<IPersonAppService>("tasksystem/person")
                .Build();
        }
    }
}
