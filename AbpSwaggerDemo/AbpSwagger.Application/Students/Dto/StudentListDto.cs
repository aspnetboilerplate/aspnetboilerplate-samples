using Abp.Application.Services.Dto;

namespace AbpSwagger.Application.Students.Dto
{
    public class StudentListDto : EntityDto<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Sno { get; set; }

        public int ClassId { get; set; }
    }
}
