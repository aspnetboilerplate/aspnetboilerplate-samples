using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace AbpPerformanceTestApp
{
    [Table("PbPersons")]
    public class Person : Entity<int>
    {
        public virtual string Name { get; set; }
        
        public virtual string PhoneNumber { get; set; }
    }
}
