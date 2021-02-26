using System.ComponentModel.DataAnnotations;

namespace AbpCoreEf6Sample.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}