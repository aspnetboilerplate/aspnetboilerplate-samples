using System;
using System.Data.Common;
using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using SimpleTaskSystem.EntityFramework;
using SimpleTaskSystem.Test.InitialData;

namespace SimpleTaskSystem.Test
{
    /// <summary>
    /// This is base class for all our test classes.
    /// It prepares ABP system, modules and a fake, in-memory database.
    /// Seeds database with initial data (<see cref="SimpleTaskSystemInitialDataBuilder"/>).
    /// Provides methods to easily work with DbContext.
    /// </summary>
    public abstract class SimpleTaskSystemTestBase : AbpIntegratedTestBase
    {
        protected SimpleTaskSystemTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Seed initial data
            UsingDbContext(context => new SimpleTaskSystemInitialDataBuilder().Build(context));
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<SimpleTaskSystemApplicationModule>();
            modules.Add<SimpleTaskSystemDataModule>();
        }

        public void UsingDbContext(Action<SimpleTaskSystemDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SimpleTaskSystemDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<SimpleTaskSystemDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SimpleTaskSystemDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
