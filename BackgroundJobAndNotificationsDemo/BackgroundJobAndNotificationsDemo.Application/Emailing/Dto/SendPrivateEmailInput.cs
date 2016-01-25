using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.Emailing.Dto
{
    public class SendPrivateEmailInput : IInputDto
    {
        [Required]
        [MaxLength(User.MaxUserNameLength)]
        public string UserName { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Subject { get; set; }
        
        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }

        public bool SendNotification { get; set; }
    }
}