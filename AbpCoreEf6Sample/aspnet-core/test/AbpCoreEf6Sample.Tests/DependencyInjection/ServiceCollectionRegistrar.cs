using Microsoft.Extensions.DependencyInjection;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Abp.Dependency;
using AbpCoreEf6Sample.Identity;
using Effort;
using System.Data.Common;

namespace AbpCoreEf6Sample.Tests.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            var _hostDb = DbConnectionFactory.CreateTransient();

            iocManager.IocContainer.Register(
               Component.For<DbConnection>()
                   .UsingFactoryMethod(() => _hostDb)
                   .LifestyleSingleton()
               );
        }
    }
}
