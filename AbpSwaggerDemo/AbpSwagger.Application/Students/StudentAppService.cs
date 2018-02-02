using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.UI;
using Abp.Extensions;
using AbpSwagger.Application.Students.Dto;

namespace AbpSwagger.Application.Students
{
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private static IList<StudentListDto> _list;

        public StudentAppService()
        {
            _list = new List<StudentListDto>();

            for (var i = 1; i < 10; i++)
            {
                _list.Add(new StudentListDto
                {
                    Id = i,
                    FirstName = "Student FirstName " + i,
                    LastName = "Student LastName " + i,
                    Address = "Student Address " + i,
                    ClassId = i,
                    Sno = "Sno " + i
                });
            }
        }

        public async Task<GetStudentForEditOutput> GetStudent(EntityDto input)
        {
            if (input?.Id == null)
                throw new UserFriendlyException("Id is invalid.");

            var info = _list.FirstOrDefault(x => x.Id == input.Id);

            var output = await Task.FromResult(info.MapTo<GetStudentForEditOutput>());
            
            return output;
        }

        public Task<GetStudentForEditOutput> GetStudent(EntityDto<int?> input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetStudentForEditOutput> GetStudentById(int input)
        {
            var info = _list.FirstOrDefault(x => x.Id == input);

            var output = await Task.FromResult(info.MapTo<GetStudentForEditOutput>());

            return output;
        }

        public async Task<IList<StudentListDto>> GetStudents()
        {
            var output = await Task.FromResult(_list);
            return output;
        }

        Task<PagedResultDto<StudentListDto>> IStudentAppService.GetStudentForPaging(GetStudentInput input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResultDto<StudentListDto>> GetStudentForPaging(GetStudentInput input)
        {
            var lst = _list.AsQueryable().WhereIf(!input.Filter.IsNullOrWhiteSpace(), x => x.FirstName.Contains(input.Filter)).
                   OrderBy(input.Sorting).PageBy(input);

            var dtos = await Task.FromResult(lst.ToList());

            return new PagedResultDto<StudentListDto>(
                _list.Count,
                dtos
                );
        }
    }
}
