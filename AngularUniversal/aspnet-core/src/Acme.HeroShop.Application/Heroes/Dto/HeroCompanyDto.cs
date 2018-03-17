using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.HeroShop.Heros;

namespace Acme.HeroShop.Heroes.Dto
{
    [AutoMapFrom(typeof(HeroCompany))]
    public class HeroCompanyDto : EntityDto
    {
        public string Name { get; set; }
    }
}