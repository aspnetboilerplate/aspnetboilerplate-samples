using System.ComponentModel.DataAnnotations;

namespace MassTransitSample.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}