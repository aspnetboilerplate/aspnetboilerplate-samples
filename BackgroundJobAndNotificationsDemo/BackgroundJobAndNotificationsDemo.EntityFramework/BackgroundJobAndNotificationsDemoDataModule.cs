using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using BackgroundJobAndNotificationsDemo.EntityFramework;

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
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
