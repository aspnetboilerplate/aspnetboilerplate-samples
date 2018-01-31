using System.Collections.Generic;

namespace AbpHangfireConsole.Application.Services.HangfireMeta.Dtos
{
    public class GetServersOutput
    {
        public List<string> ServerNames { get; set; }
    }
}