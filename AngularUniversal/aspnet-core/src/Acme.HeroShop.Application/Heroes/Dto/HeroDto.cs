using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.HeroShop.Heros;

namespace Acme.HeroShop.Heroes.Dto
{
    [AutoMapFrom(typeof(Hero))]
    public class HeroDto : EntityDto
    {
        public string Name { get; set; }

        public int HeroCompanyId { get; set; }
    }
}
