using System;
using System.Threading.Tasks;
using Abp.TestBase;
using AbpPerformanceTestApp.EntityFrameworkCore;
using AbpPerformanceTestApp.Tests.TestDatas;

namespace AbpPerformanceTestApp.Tests
{
    public class AbpPerformanceTestAppTestBase : AbpIntegratedTestBase<AbpPerformanceTestAppTestModule>
    {
        public AbpPerformanceTestAppTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<AbpPerformanceTestAppDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<AbpPerformanceTestAppDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<AbpPerformanceTestAppDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpPerformanceTestAppDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<AbpPerformanceTestAppDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<AbpPerformanceTestAppDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<AbpPerformanceTestAppDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpPerformanceTestAppDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
