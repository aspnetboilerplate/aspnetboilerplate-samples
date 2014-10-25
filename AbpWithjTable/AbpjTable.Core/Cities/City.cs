using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace AbpjTable.Cities
{
    [Table("Cities")]
    public class City : Entity
    {
        [Required]
        public virtual string Name { get; set; }

        public City()
        {
            
        }

        public City(string name)
        {
            Name = name;
        }
    }
}