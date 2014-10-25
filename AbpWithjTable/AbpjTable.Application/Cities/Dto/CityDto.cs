using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace AbpjTable.Cities.Dto
{
    public class CityDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
    }
}