using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using AbpWcfDemo.Beachs;

namespace AbpWcfDemo.Events {

    [Table("SoapEvent")]
    public class Event : Entity<int> {
        public virtual string Title { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime? End { get; set; }

        [Required]
        public int BeachId { get; set; }
        [ForeignKey(nameof(BeachId))]
        public Beach Beach { get; set; }
    }
}