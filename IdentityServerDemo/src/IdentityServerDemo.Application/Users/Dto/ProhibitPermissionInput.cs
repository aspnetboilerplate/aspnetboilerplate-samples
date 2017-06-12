using System.ComponentModel.DataAnnotations;

namespace IdentityServerDemo.Users.Dto
{
    public class ProhibitPermissionInput
    {
        [Range(1, long.MaxValue)]
        public int UserId { get; set; }

        [Required]
        public string PermissionName { get; set; }
    }
}