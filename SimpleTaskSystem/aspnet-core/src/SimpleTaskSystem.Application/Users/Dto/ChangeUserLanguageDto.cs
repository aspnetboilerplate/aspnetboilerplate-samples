using System.ComponentModel.DataAnnotations;

namespace SimpleTaskSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}