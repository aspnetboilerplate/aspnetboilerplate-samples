using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using BackgroundJobAndNotificationsDemo.Emailing.Dto;
using BackgroundJobAndNotificationsDemo.Users;
using Castle.Core.Logging;

namespace BackgroundJobAndNotificationsDemo.Emailing
{
    [AbpAuthorize]
    public class PrivateEmailAppService : BackgroundJobAndNotificationsDemoAppServiceBase, IPrivateEmailAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly INotificationManager _notificationManager;

        public PrivateEmailAppService(IBackgroundJobManager backgroundJobManager, INotificationManager notificationManager)
        {
            _backgroundJobManager = backgroundJobManager;
            _notificationManager = notificationManager;
        }

        public async Task Send(SendPrivateEmailInput input)
        {
            var targetUser = await UserManager.FindByNameAsync(input.UserName);
            if (targetUser == null)
            {
                throw new UserFriendlyException("There is no such a user: " + input.UserName);
            }

            var currentUser = await GetCurrentUserAsync();

            await _backgroundJobManager.EnqueueAsync<SendPrivateEmailJob, SendPrivateEmailJobArgs>(
                new SendPrivateEmailJobArgs
                {
                    Subject = input.Subject,
                    Body = input.Body,
                    SenderUserId = currentUser.Id,
                    TargetTenantId = AbpSession.TenantId,
                    TargetUserId = targetUser.Id
                });

            if (input.SendNotification)
            {
                await _notificationManager.PublishAsync(
                    new NotificationPublishOptions(
                        NotificationNames.YouHaveAnEmail,
                        new YouHaveAnEmailNotificationData(currentUser.UserName, input.Subject),
                        userIds: new[] { targetUser.Id }
                        )
                    );
            }
        }
    }

    public static class NotificationNames
    {
        public const string YouHaveAnEmail = "App.YouHaveAnEmail";
    }

    public class YouHaveAnEmailNotificationData : NotificationData
    {
        public string SenderName { get; set; }

        public string Subject { get; set; }

        public YouHaveAnEmailNotificationData(string senderName, string subject)
        {
            SenderName = senderName;
            Subject = subject;
        }
    }
}
