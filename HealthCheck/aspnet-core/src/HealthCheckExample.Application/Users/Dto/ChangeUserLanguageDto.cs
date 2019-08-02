using System.ComponentModel.DataAnnotations;

namespace HealthCheckExample.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}