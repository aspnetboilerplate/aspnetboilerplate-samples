using System.ComponentModel.DataAnnotations;

namespace Volo.PostgreSqlDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}