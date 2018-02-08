using System.ComponentModel.DataAnnotations;

namespace AbpKendoDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}