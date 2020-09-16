using System.ComponentModel.DataAnnotations;

namespace IdentityServerWithEfCoreDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}