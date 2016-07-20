using Abp.Modules;
using Abp.TestBase;

namespace InterceptionDemo.Tests
{
    [DependsOn(typeof(AbpTestBaseModule), typeof(InterceptionDemoApplicationModule), typeof(InterceptionDemoDataModule))]
    public class InterceptionDemoTestModule : AbpModule
    {
        
    }
}