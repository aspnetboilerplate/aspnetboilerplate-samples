using System.Reflection;
using Abp.Modules;
using Abp.Runtime.Validation.Interception;
using AbpHangfireConsole.Hangfire.Framework;
using Castle.Core;
using Castle.MicroKernel;

namespace AbpHangfireConsole.Hangfire
{
    public class AbpHangfireConsoleHangfireModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Ensure our input classes are validated when used
            IocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        /// <summary>
        ///     Method called to allow us to perform some additional processing when a component is registered via IoC
        /// </summary>
        /// <param name="aKey"></param>
        /// <param name="aHandler"></param>
        private void Kernel_ComponentRegistered(string aKey, IHandler aHandler)
        {
            if (typeof(IHangfireParamsInputBase).GetTypeInfo().IsAssignableFrom(aHandler.ComponentModel.Implementation))
                //Add validation to the inputs for jobs
                aHandler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ValidationInterceptor)));
        }

    }
}