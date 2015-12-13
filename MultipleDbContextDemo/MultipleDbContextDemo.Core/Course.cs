using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultipleDbContextDemo
{
    [Table("Courses")] //In second database
    public class Course : Entity
    {
        public virtual string CourseName { get; set; }
    }
}