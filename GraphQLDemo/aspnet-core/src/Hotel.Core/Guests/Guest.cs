using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Hotel.Guests
{
    public class Guest : Entity
    {
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }

        public Guest()
        {

        }

        public Guest(string name, DateTime registerDate)
        {
            Name = name;
            RegisterDate = registerDate;
        }
    }
}
