using System.ComponentModel.DataAnnotations;

namespace IdentityServerDemo.SSO.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}