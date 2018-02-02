using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.ProjectName.Authorization;

namespace Acme.ProjectName
{
    [DependsOn(
        typeof(ProjectNameCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProjectNameApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProjectNameAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjectNameApplicationModule).GetAssembly());
        }
    }
}