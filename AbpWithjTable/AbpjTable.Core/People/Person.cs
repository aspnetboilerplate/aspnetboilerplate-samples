using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AbpjTable.Cities;

namespace AbpjTable.People
{
    [Table("People")]
    public class Person : AuditedEntity, ISoftDelete
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Surname { get; set; }

        [ForeignKey("BirthCityId")]
        public virtual City BirthCity { get; set; }
        
        public virtual int BirthCityId { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual bool IsDeleted { get; set; }

        public Person()
        {
            
        }

        public Person(string name, string surname, City birthCity, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthCity = birthCity;
            BirthDate = birthDate;
        }
    }
}
