
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Attributes;
using AbpSwagger.Application.Classes.Dto;

namespace AbpSwagger.Application.Classes
{
    [WebApiDescription("Class", "WebApi help for Class")]
    public interface IClassAppService : IApplicationService
    {
        [HttpGet]
        [WebApiDescription("Class", "Get all classes.")]
        Task<IList<ClassListDto>> GetClasses();
    }
}
