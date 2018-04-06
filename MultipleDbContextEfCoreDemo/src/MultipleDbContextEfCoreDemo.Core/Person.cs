using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultipleDbContextEfCoreDemo
{
    [Table("Persons")] //In first database
    public class Person : Entity
    {
        public virtual string PersonName { get; set; }

        public Person()
        {

        }

        public Person(string personName)
        {
            PersonName = personName;
        }
    }
}
