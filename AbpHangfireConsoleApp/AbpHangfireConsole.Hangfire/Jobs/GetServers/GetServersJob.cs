using AbpHangfireConsole.Application.Services.HangfireMeta;
using AbpHangfireConsole.Application.Services.HangfireMeta.Dtos;
using AbpHangfireConsole.Hangfire.Framework;
using AbpHangfireConsole.Hangfire.Jobs.GetServers.Dtos;
using Hangfire.Console;
using Hangfire.Server;

namespace AbpHangfireConsole.Hangfire.Jobs.GetServers
{
    /// <summary>
    ///     Hangfire job to list the servers hangfire knows about directly from its database table Hangfire.Server
    /// </summary>
    public class GetServersJob : HangfireJobBase<GetServersParamsInput>
    {
        private readonly IHangfireMetaService _HangfireMetaService;

        public GetServersJob(IHangfireMetaService aHangfireMetaService)
        {
            _HangfireMetaService = aHangfireMetaService;
        }

        /// <summary>
        ///     Called when the job is to be executed.
        /// </summary>
        /// <param name="aContext">Context of the job within HangFire.</param>
        /// <param name="aParams">Parameters for the job being executed.</param>
        public override void ExecuteJob(PerformContext aContext, GetServersParamsInput aParams)
        {
            var getServersOutput = _HangfireMetaService.GetServers(new GetServersInput());

            aContext.WriteLine($"# Servers Found:{getServersOutput.ServerNames.Count}");
            aContext.WriteLine("");
            foreach (var serverName in getServersOutput.ServerNames)
            {
                aContext.WriteLine(serverName);
            }
        }
    }
}