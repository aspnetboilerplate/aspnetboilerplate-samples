using System.ComponentModel.DataAnnotations;

namespace AbpCoreEf7JsonColumnDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}