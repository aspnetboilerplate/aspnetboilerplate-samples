using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SimpleTaskSystem.People;

namespace SimpleTaskSystem.Tasks
{
    public class Task : Entity<long>
    {
        public virtual Person AssignedPerson { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState State { get; set; }

        public Task()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Active;
        }
    }
}
