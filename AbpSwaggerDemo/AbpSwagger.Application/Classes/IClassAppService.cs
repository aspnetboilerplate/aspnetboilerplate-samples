using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using AbpSwagger.Application.Classes.Dto;

namespace AbpSwagger.Application.Classes
{
    public interface IClassAppService : IApplicationService
    {
        [HttpGet]
        Task<IList<ClassListDto>> GetClasses();
    }
}
