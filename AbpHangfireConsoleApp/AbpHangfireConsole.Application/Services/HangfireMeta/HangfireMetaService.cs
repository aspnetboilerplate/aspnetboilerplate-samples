using System.Collections.Generic;
using AbpHangfireConsole.Application.Services.HangfireMeta.Dtos;
using AbpHangfireConsole.Core.Repositories;
using AbpHangfireConsole.Core.TableModels;

namespace AbpHangfireConsole.Application.Services.HangfireMeta
{
    public class HangfireMetaService : HangfireConsoleAppAppServiceBase, IHangfireMetaService
    {
        private readonly IHangfireServerRepository _aHangfireServerRepository;

        public HangfireMetaService(IHangfireServerRepository aHangfireServerRepository)
        {
            _aHangfireServerRepository = aHangfireServerRepository;
        }

        public GetServersOutput GetServers(GetServersInput aParams)
        {
            var result = new GetServersOutput();

            var servers = _aHangfireServerRepository.GetAllList();
            var serverNameList = new List<string>();
            foreach (Hangfire_ServerModel hangfireServerModel in servers)
            {
                serverNameList.Add(hangfireServerModel.Id);
            }

            result.ServerNames = serverNameList;

            return result;
        }
    }
}