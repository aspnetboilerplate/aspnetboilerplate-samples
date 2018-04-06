using System;
using System.Threading.Tasks;
using Abp.TestBase;
using MultipleDbContextEfCoreDemo.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Tests.TestDatas;

namespace MultipleDbContextEfCoreDemo.Tests
{
    public class MultipleDbContextEfCoreDemoTestBase : AbpIntegratedTestBase<MultipleDbContextEfCoreDemoTestModule>
    {
        public MultipleDbContextEfCoreDemoTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MultipleDbContextEfCoreDemoDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MultipleDbContextEfCoreDemoDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MultipleDbContextEfCoreDemoDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MultipleDbContextEfCoreDemoDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MultipleDbContextEfCoreDemoDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MultipleDbContextEfCoreDemoDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MultipleDbContextEfCoreDemoDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MultipleDbContextEfCoreDemoDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
