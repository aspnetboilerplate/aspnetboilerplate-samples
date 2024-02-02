using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptionDemo.Tasks
{
    public class Task: Entity
    {
        public int AssignedUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description, int assignedUserId)
        {
            Title = title;
            Description = description;
            AssignedUserId = assignedUserId;
        }
    }
}
