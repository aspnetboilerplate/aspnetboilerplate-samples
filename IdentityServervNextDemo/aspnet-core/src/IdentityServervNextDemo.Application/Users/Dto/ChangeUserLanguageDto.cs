using System.ComponentModel.DataAnnotations;

namespace IdentityServervNextDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}