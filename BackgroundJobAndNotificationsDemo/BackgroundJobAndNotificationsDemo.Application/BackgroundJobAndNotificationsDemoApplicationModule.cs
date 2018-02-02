using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace BackgroundJobAndNotificationsDemo
{
    [DependsOn(typeof(BackgroundJobAndNotificationsDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class BackgroundJobAndNotificationsDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
