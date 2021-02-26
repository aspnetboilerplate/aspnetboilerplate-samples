using System.ComponentModel.DataAnnotations;

namespace AbpCoreEf6Sample.Users.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
