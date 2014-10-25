using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpjTable.Cities;
using AbpjTable.People.Dto;

namespace AbpjTable.People
{
    public interface IPersonAppService : IApplicationService
    {
        PagedResultOutput<PersonDto> GetPeople(GetPeopleInput input);
    }
}
