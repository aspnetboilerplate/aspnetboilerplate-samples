using Abp.Application.Services;
using BackgroundJobAndNotificationsDemo.Emailing.Dto;

namespace BackgroundJobAndNotificationsDemo.Emailing
{
    public interface IPrivateEmailAppService : IApplicationService
    {
        void Send(SendPrivateEmailInput input);
    }
}