using System.ComponentModel.DataAnnotations;

namespace Volo.SqliteDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}