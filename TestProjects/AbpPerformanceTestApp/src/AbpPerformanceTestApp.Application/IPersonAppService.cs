using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpPerformanceTestApp.Dto;

namespace AbpPerformanceTestApp
{
    public interface IPersonAppService : IApplicationService
    {
        Task<List<Person>> GetPeople();

        Task<int> InsertAndGetId(InsertAndGetIdInput input);

        Task Delete(EntityDto input);

        int GetConstant();
    }
}
