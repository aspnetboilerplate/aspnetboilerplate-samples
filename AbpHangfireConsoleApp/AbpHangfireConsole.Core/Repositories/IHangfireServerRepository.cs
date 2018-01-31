using Abp.Domain.Repositories;
using AbpHangfireConsole.Core.TableModels;

namespace AbpHangfireConsole.Core.Repositories
{
    /// <summary>
    ///     Repository access to Hangfire.Server
    /// </summary>
    public interface IHangfireServerRepository : IRepository<Hangfire_ServerModel, string>
    {
    }
}