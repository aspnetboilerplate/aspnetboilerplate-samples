using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace BackgroundJobAndNotificationsDemo.Users.Dto
{
    public class ProhibitPermissionInput : EntityDto
    {
        [Range(1, long.MaxValue)]
        public int UserId { get; set; }

        [Required]
        public string PermissionName { get; set; }
    }
}