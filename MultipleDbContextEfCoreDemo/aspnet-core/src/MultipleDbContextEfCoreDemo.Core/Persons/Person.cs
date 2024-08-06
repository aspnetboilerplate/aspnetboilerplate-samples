using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleDbContextEfCoreDemo.Persons
{
    //In first database
    [Table("Persons")]
    public class Person : Entity
    {
        public string Name { get; set; }
    }
}
