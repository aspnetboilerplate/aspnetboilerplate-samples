using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;

namespace AbpjTable.Cities
{
    public class CityAppService : ICityAppService
    {
        private readonly IRepository<City> _cityRepository;

        public CityAppService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ListResultOutput<ComboboxItemDto> GetAllCities()
        {
            return new ListResultOutput<ComboboxItemDto>
                   {
                       Items = _cityRepository.GetAllList().ConvertAll(c => new ComboboxItemDto(c.Id.ToString(), c.Name))
                   };
        }
    }
}