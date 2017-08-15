using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpPerformanceTestApp
{
    public interface IPersonAppService : IApplicationService
    {
        Task<ListResultDto<PersonListDto>> GetPeople(GetPeopleInput input);

        Task<int> InsertAndGetId(InsertAndGetIdInput input);

        Task Delete(EntityDto input);

        int GetConstant();
    }

    public class InsertAndGetIdInput
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }


    public class GetPeopleInput
    {
        public string Filter { get; set; }
    }


    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : EntityDto
    {
        public  string Name { get; set; }

        public  string PhoneNumber { get; set; }
    }
}
