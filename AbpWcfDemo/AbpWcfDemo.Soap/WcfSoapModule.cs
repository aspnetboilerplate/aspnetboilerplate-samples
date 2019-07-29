using System.Reflection;
using Abp.Modules;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using AbpWcfDemo.Wcf;

namespace AbpWcfDemo {

    /// <summary>
    ///     TODO: I am not sure this class is required. In WebApi project is is used to automatically create the REST web services
    /// </summary>
    [DependsOn(typeof(WcfCoreModule), typeof(WcfApplicationModule))]
    public class WcfSoapModule : AbpModule {
        public override void PreInitialize() {
        }

        public override void Initialize() {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // EXAMPLE of how to register for injection a single SOAP service
            //IocManager.IocContainer.AddFacility<WcfFacility>().Register(
            //    Component
            //        .For<IMyService>()
            //          .ImplementedBy<MyService>()
            //          .Named("MyService")
            //);

            // register for IOC injection all SOAP services defined in this module
            IocManager.IocContainer.AddFacility<WcfFacility>().Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IAbpService>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .LifestyleTransient()
                );

            Configuration.Authorization.IsEnabled = false;
        }

        public override void PostInitialize() {
        }
    }
}
