using System.ComponentModel.DataAnnotations;

namespace InterceptionDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}