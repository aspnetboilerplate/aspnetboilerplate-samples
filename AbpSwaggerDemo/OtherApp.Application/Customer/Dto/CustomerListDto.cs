using Abp.Application.Services.Dto;

namespace OtherApp.Application.Customer.Dto
{
    public class CustomerListDto : EntityDto<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
