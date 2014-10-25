using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace AbpjTable.People.Dto
{
    public class PersonDto : EntityDto
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Surname { get; set; }

        public virtual string BirthCityId { get; set; }

        public virtual DateTime BirthDate { get; set; }
    }
}