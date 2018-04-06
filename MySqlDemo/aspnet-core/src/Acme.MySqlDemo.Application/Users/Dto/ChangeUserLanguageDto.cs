using System.ComponentModel.DataAnnotations;

namespace Acme.MySqlDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}