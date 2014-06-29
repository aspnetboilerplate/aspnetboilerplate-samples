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
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
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
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .For<ITaskAppService>("tasksystem/task")
                .Build();

            DynamicApiControllerBuilder
                .For<IPersonAppService>("tasksystem/person")
                .Build();
        }
    }
}
