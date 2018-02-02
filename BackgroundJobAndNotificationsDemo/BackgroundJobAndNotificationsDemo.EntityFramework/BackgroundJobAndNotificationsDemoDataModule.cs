using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFramework;

namespace BackgroundJobAndNotificationsDemo
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(BackgroundJobAndNotificationsDemoCoreModule))]
    public class BackgroundJobAndNotificationsDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackgroundJobAndNotificationsDemoDataModule).GetAssembly());
        }
    }
}
