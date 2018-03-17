using System.Collections.Generic;
using Abp.Application.Services;
using Acme.HeroShop.Heroes.Dto;

namespace Acme.HeroShop.Heroes
{
    public interface IHeroAppService : IApplicationService
    {
        List<HeroDto> GetHeroes(int? heroCompanyId);

        List<HeroCompanyDto> GetHeroCompanies();
    }
}