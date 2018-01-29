using System.Collections.Generic;
using System.Linq;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Acme.HeroShop.Heroes.Dto;
using Acme.HeroShop.Heros;

namespace Acme.HeroShop.Heroes
{
    public class HeroAppService : HeroShopAppServiceBase, IHeroAppService
    {
        private readonly IRepository<Hero> _heroRepository;
        private readonly IRepository<HeroCompany> _heroCompanyRepository;

        public HeroAppService(
            IRepository<Hero> heroRepository,
            IRepository<HeroCompany> heroCompanyRepository)
        {
            _heroRepository = heroRepository;
            _heroCompanyRepository = heroCompanyRepository;
        }

        public List<HeroDto> GetHeroes(int? heroCompanyId)
        {
            var heroes = _heroRepository.GetAll()
                .WhereIf(heroCompanyId.HasValue, hero => hero.HeroCompanyId == heroCompanyId.Value)
                .OrderBy(h => h.Name)
                .ToList();

            return ObjectMapper.Map<List<HeroDto>>(heroes);
        }

        public List<HeroCompanyDto> GetHeroCompanies()
        {
            return ObjectMapper.Map<List<HeroCompanyDto>>(
                _heroCompanyRepository.GetAllList()
            );
        }
    }
}