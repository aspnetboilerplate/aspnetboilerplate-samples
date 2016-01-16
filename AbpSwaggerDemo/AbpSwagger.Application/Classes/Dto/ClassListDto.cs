using Abp.Application.Services.Dto;

namespace AbpSwagger.Application.Classes.Dto
{
    public class ClassListDto : EntityDto<int>
    {
        public string ClassName { get; set; }
    }
}
