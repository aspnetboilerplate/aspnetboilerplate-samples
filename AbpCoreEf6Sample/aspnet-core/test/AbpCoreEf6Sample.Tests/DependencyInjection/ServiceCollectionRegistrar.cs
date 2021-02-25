using System;
using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Abp.Dependency;
using AbpCoreEf6Sample.EntityFrameworkCore;
using AbpCoreEf6Sample.Identity;

namespace AbpCoreEf6Sample.Tests.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            services.AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            var builder = new DbContextOptionsBuilder<AbpCoreEf6SampleDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<AbpCoreEf6SampleDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}
