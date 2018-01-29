using Abp.Domain.Entities;

namespace Acme.HeroShop.Heros
{
    public class Hero : Entity
    {
        public string Name { get; set; }

        public int HeroCompanyId { get; set; }
    }
}