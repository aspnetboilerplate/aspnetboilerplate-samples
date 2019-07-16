using System.ComponentModel.DataAnnotations;

namespace Hotel.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}