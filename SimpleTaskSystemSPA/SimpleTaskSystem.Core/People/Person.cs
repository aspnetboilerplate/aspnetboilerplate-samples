using Abp.Domain.Entities;

namespace SimpleTaskSystem.People
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}