using System.ComponentModel.DataAnnotations;

namespace Acme.HeroShop.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}