using System;
using System.Threading.Tasks;
using Abp.TestBase;
using IdentityServerDemo.Api.EntityFrameworkCore;
using IdentityServerDemo.Api.Tests.TestDatas;

namespace IdentityServerDemo.Api.Tests
{
    public class ApiTestBase : AbpIntegratedTestBase<ApiTestModule>
    {
        public ApiTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ApiDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ApiDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ApiDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ApiDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ApiDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ApiDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ApiDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ApiDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
