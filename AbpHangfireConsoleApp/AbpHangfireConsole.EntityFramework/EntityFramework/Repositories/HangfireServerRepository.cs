using Abp.EntityFramework;
using AbpHangfireConsole.Core.Repositories;
using AbpHangfireConsole.Core.TableModels;

namespace AbpHangfireConsole.EntityFramework.EntityFramework.Repositories
{
    /// <summary>
    ///     Concrete EF implementation of IOzCpReferenceCountryRepository
    /// </summary>
    public class HangfireServerRepository : HangfireConsoleAppRepositoryBase<Hangfire_ServerModel, string>, IHangfireServerRepository
    {
        /// <summary>
        ///     Class constructor.
        /// </summary>
        /// <param name="aDbContextProvider">Data context containing the entity.</param>
        public HangfireServerRepository(IDbContextProvider<AbpHangfireConsoleDbContext> aDbContextProvider)
            : base(aDbContextProvider)
        {
        }
    }
}