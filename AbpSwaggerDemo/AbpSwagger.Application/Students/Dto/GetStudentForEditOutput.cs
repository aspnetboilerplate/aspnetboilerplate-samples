using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpSwagger.Application.Students.Dto
{
    [AutoMap(typeof(StudentListDto))]
    public class GetStudentForEditOutput : IOutputDto
    {
        [Description("Customer Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Description("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [Description("Last Name")]
        public string LastName { get; set; }

        [StringLength(125)]
        [Description("Address")]
        public string Address { get; set; }

        [StringLength(10)]
        [Description("Student No.")]
        public string Sno { get; set; }
        
        [Description("Class Id")]
        public int ClassId { get; set; }

    }
}
