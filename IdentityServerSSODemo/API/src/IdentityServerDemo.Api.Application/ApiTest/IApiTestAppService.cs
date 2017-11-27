using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;

namespace IdentityServerDemo.Api.ApiTest
{
    public interface IApiTestAppService : IApplicationService
    {
        IList<int> Get();
    }
}
