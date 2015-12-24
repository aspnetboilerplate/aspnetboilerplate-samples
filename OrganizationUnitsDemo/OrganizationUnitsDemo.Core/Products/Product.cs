using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Organizations;

namespace OrganizationUnitsDemo.Products
{
    [Table("AppProducts")]
    public class Product : Entity, IMustHaveOrganizationUnit
    {
        public virtual long OrganizationUnitId { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public Product()
        {
            
        }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
