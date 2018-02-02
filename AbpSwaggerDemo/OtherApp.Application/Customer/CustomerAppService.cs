using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Extensions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using OtherApp.Application.Customer.Dto;

namespace OtherApp.Application.Customer
{
    public class CustomerAppService : ApplicationService , ICustomerAppService
    {
        private static IList<CustomerListDto> _list;

        public CustomerAppService()
        {
            _list = new List<CustomerListDto>();

            for (var i = 1; i < 10; i++)
            {
                _list.Add(new CustomerListDto
                {
                    Id = i,
                    FirstName = "FirstName " + i,
                    LastName = "LastName " + i
                });
            }
        }

        public async Task<IList<CustomerListDto>> GetCustomerByName(string name)
        {
            var lst = _list.AsQueryable().WhereIf(!name.IsNullOrWhiteSpace(),
                x => x.FirstName.Contains(name) || x.LastName.Contains(name));

            var list = await Task.FromResult(lst.ToList());

            return list;
        }

        public async Task<CustomerListDto> GetCustomerById(EntityDto input)
        {
            var lst = _list.FirstOrDefault(x => x.Id == input.Id);

            var model = await Task.FromResult(lst);

            return model;
        }
    }
}
