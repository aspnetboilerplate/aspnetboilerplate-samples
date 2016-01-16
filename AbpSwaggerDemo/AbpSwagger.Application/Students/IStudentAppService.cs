using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Attributes;
using Abp.Application.Services.Dto;
using AbpSwagger.Application.Students.Dto;

namespace AbpSwagger.Application.Students
{
    [WebApiDescription("Student", "WebApi help for student")]
    public interface IStudentAppService : IApplicationService
    {
        [HttpPost]
        [WebApiDescription("Student", "Get student by id.")]
        Task<GetStudentForEditOutput> GetStudent([Description("Plese enter customer id.")]NullableIdInput input);

        [HttpPost]
        [WebApiDescription("Student", "Get student by id.")]
        Task<GetStudentForEditOutput> GetStudentById([Description("Plese enter customer id."), Required]int input);

        [HttpGet]
        [WebApiDescription("Student", "Get all students.")]
        Task<IList<StudentListDto>> GetStudents();

        [HttpPost]
        [WebApiDescription("Student", "Get student by GetStudentInput.")]
        Task<PagedResultOutput<StudentListDto>> GetStudentForPaging([Description("Get customer input.")]GetStudentInput input);
    }
}
