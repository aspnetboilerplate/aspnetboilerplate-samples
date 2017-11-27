using System;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;

namespace IdentityServerDemo.Api.ApiTest
{
    [AbpAuthorize]
    public class ApiTestAppService : ApiAppServiceBase, IApiTestAppService
    {
        public IList<int> Get()
        {
            return new List<int> {1, 2};
        }
    }
}
