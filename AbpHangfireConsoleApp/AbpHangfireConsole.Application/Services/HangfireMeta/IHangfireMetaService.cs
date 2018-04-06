using Abp.Application.Services;
using AbpHangfireConsole.Application.Services.HangfireMeta.Dtos;

namespace AbpHangfireConsole.Application.Services.HangfireMeta
{
    public interface IHangfireMetaService : IApplicationService
    {
        GetServersOutput GetServers(GetServersInput aParams);
    }
}