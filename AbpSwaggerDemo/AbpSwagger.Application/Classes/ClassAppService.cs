using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using AbpSwagger.Application.Classes.Dto;

namespace AbpSwagger.Application.Classes
{
    public class ClassAppService : ApplicationService, IClassAppService
    {
        private static IList<ClassListDto> _list;

        public ClassAppService()
        {
            _list = new List<ClassListDto>();

            for (int i = 1; i <= 10; i++)
            {
                _list.Add(new ClassListDto
                {
                    Id = i,
                    ClassName = "ClassName " + i
                });
            }
        }

        public async Task<IList<ClassListDto>> GetClasses()
        {
            var list = await Task.FromResult(_list);

            return list;
        }
    }
}
