using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultipleDbContextEfCoreDemo
{
    [Table("Courses")] //In second database
    public class Course : Entity
    {
        public virtual string CourseName { get; set; }

        public Course()
        {

        }

        public Course(string courseName)
        {
            CourseName = courseName;
        }
    }
}