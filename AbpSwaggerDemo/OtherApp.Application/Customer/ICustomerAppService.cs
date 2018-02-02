using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OtherApp.Application.Customer.Dto;

namespace OtherApp.Application.Customer
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<IList<CustomerListDto>> GetCustomerByName([Description("Plese enter name."), Required]string name);

        Task<CustomerListDto> GetCustomerById([Description("Plese enter id."), Required]EntityDto input);
    }
}
