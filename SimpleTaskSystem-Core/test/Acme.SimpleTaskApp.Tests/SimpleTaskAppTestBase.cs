using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Acme.SimpleTaskApp.EntityFrameworkCore;
using Acme.SimpleTaskApp.Tests.TestDatas;

namespace Acme.SimpleTaskApp.Tests
{
    public class SimpleTaskAppTestBase : AbpIntegratedTestBase<SimpleTaskAppTestModule>
    {
        public SimpleTaskAppTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<SimpleTaskAppDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SimpleTaskAppDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<SimpleTaskAppDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SimpleTaskAppDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<SimpleTaskAppDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<SimpleTaskAppDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<SimpleTaskAppDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SimpleTaskAppDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
