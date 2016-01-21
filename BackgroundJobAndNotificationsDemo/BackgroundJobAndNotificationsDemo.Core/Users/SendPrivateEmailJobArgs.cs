using System;

namespace BackgroundJobAndNotificationsDemo.Users
{
    [Serializable]
    public class SendPrivateEmailJobArgs
    {
        public long SenderUserId { get; set; }

        public int? TargetTenantId { get; set; }

        public long TargetUserId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}