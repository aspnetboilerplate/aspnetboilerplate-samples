using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Organizations;

namespace OrganizationUnitsDemo.Products
{
    [Table("AppProducts")]
    public class Product : Entity, IMustHaveTenant, IMustHaveOrganizationUnit
    {
        public virtual int TenantId { get; set; }

        public virtual long OrganizationUnitId { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public Product()
        {
            
        }

        public Product(int tenantId, long organizationUnitId, string name, float price)
        {
            TenantId = tenantId;
            OrganizationUnitId = organizationUnitId;
            Name = name;
            Price = price;
        }
    }
}
