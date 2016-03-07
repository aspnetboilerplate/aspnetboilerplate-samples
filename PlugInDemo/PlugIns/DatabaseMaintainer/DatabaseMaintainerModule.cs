using System.Reflection;
using Abp.Modules;
using Abp.Threading.BackgroundWorkers;
using Abp.Zero;

namespace DatabaseMaintainer
{
    [DependsOn(typeof (AbpZeroCoreModule))]
    public class DatabaseMaintainerModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<DeleteOldAuditLogsWorker>());
        }
    }
}
