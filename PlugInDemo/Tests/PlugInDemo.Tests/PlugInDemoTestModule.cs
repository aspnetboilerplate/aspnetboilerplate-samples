using Abp.Modules;
using Abp.TestBase;

namespace PlugInDemo.Tests
{
    [DependsOn(
         typeof(PlugInDemoApplicationModule),
         typeof(PlugInDemoDataModule),
         typeof(AbpTestBaseModule)
     )]
    public class PlugInDemoTestModule : AbpModule
    {
        
    }
}