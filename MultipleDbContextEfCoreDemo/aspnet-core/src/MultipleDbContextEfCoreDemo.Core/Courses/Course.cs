using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleDbContextEfCoreDemo.Courses
{
    //In second database
    [Table("Courses")]
    public class Course: Entity
    {
        public string Name { get; set; }
    }
}
