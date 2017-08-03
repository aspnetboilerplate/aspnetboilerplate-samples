using Abp.Application.Services.Dto;

namespace Acme.PhoneBook.Authorization.Users.Dtos
{
    public class UpdateEmailDto:EntityDto
    {
        public string EmailAddress { get; set; }
    }
}