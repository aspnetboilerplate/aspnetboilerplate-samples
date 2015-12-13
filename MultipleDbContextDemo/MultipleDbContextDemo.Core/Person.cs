using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultipleDbContextDemo
{
    [Table("Persons")] //In first database
    public class Person : Entity
    {
        public virtual string PersonName { get; set; }
    }
}
