using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using AbpWcfDemo.Events;

namespace AbpWcfDemo.Beachs {

    [Table("BeachEvent")]
    public class Beach : Entity<int> {

        public Beach() {
            Events = new HashSet<Event>();
        }

        public virtual string Name { get; set; }
        public virtual String Address { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}