using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace BackgroundJobAndNotificationsDemo
{
    [DependsOn(typeof(BackgroundJobAndNotificationsDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class BackgroundJobAndNotificationsDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackgroundJobAndNotificationsDemoApplicationModule).GetAssembly());
        }
    }
}
