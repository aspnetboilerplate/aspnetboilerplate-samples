using System.ComponentModel.DataAnnotations;

namespace MultipleDbContextEfCoreDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}