using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;
using Abp.WebApi.Controllers.Dynamic.Builders;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem
{
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DyanmicApiControllerBuilder
                .For<ITaskAppService>("tasksystem/task")
                .Build();

            DyanmicApiControllerBuilder
                .For<IPersonAppService>("tasksystem/person")
                .Build();
        }
    }
}
