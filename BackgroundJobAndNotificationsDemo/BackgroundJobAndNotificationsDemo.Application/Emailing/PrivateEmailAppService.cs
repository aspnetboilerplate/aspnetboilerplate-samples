using System.Threading.Tasks;
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Notifications;
using Abp.UI;
using BackgroundJobAndNotificationsDemo.Emailing.Dto;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.Emailing
{
    [AbpAuthorize]
    public class PrivateEmailAppService : BackgroundJobAndNotificationsDemoAppServiceBase, IPrivateEmailAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly INotificationPublisher _notificationPublisher;

        public PrivateEmailAppService(IBackgroundJobManager backgroundJobManager, INotificationPublisher notificationPublisher)
        {
            _backgroundJobManager = backgroundJobManager;
            _notificationPublisher = notificationPublisher;
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
                var notificationData = new MessageNotificationData(
                    string.Format("{0} sent you an email with subject: {1}",
                        currentUser.UserName,
                        input.Subject
                        )
                    );

                await _notificationPublisher.PublishAsync(NotificationNames.YouHaveAnEmail, notificationData, userIds: new[] { targetUser.ToUserIdentifier() });
            }
        }
    }

    public static class NotificationNames
    {
        public const string YouHaveAnEmail = "App.YouHaveAnEmail";
    }
}
