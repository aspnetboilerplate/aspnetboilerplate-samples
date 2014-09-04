using System;
using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;

namespace SimpleTaskSystem
{
    /// <summary>
    /// 'Aplication layer module' for this project.
    /// </summary>
    public class SimpleTaskSystemApplicationModule : AbpModule
    {
        /// <summary>
        /// We declare depended modules explicitly.
        /// </summary>
        public override Type[] GetDependedModules()
        {
            return new[]
                   {
                       typeof(SimpleTaskSystemCoreModule)
                   };
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);

            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //We must declare mappings to be able to use AutoMapper
            DtoMappings.Map();
        }
    }
}
