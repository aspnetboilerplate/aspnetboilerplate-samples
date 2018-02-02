using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpSwagger.Application.Students.Dto;

namespace AbpSwagger.Application.Students
{
    public interface IStudentAppService : IApplicationService
    {
        [HttpPost]
        Task<GetStudentForEditOutput> GetStudent([Description("Plese enter customer id.")]EntityDto<int?> input);

        [HttpPost]
        Task<GetStudentForEditOutput> GetStudentById([Description("Plese enter customer id."), Required]int input);

        [HttpGet]
        Task<IList<StudentListDto>> GetStudents();

        [HttpPost]
        Task<PagedResultDto<StudentListDto>> GetStudentForPaging([Description("Get customer input.")]GetStudentInput input);
    }
}
