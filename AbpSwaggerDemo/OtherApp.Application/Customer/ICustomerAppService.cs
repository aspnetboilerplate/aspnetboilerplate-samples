using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Attributes;
using Abp.Application.Services.Dto;
using OtherApp.Application.Customer.Dto;

namespace OtherApp.Application.Customer
{
    [WebApiDescription("Customer", "WebApi help for customer")]
    public interface ICustomerAppService : IApplicationService
    {
        [WebApiDescription("Customer", "Get  customer by name")]
        Task<IList<CustomerListDto>> GetCustomerByName([Description("Plese enter name."), Required]string name);

        [WebApiDescription("Customer", "Get  customer by id")]
        Task<CustomerListDto> GetCustomerById([Description("Plese enter id."), Required]IdInput input);
    }
}
