using System;
using Abp.Domain.Entities;

namespace AbpEfConsoleApp
{
    //A domain entity
    public class User : Entity<Guid>
    {
        public virtual string Name { get; set; }

        public User()
        {

        }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("[User {0}] {1}", Id, Name);
        }
    }
}