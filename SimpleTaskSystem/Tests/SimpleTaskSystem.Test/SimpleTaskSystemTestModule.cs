using Abp.Modules;

namespace SimpleTaskSystem.Test
{
    [DependsOn(
         typeof(SimpleTaskSystemDataModule),
         typeof(SimpleTaskSystemApplicationModule)
     )]
    public class SimpleTaskSystemTestModule : AbpModule
    {
        
    }
}