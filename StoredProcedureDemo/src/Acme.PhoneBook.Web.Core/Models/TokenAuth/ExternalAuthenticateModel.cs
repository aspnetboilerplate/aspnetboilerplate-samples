using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace Acme.PhoneBook.Models.TokenAuth
{
    public class ExternalAuthenticateModel
    {
        [Required]
        [MaxLength(UserLogin.MaxLoginProviderLength)]
        public string AuthProvider { get; set; }

        [Required]
        [MaxLength(UserLogin.MaxProviderKeyLength)]
        public string ProviderKey { get; set; }

        [Required]
        public string ProviderAccessCode { get; set; }
    }
}
