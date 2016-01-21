using System.Threading.Tasks;
using Abp.Application.Services;
using BackgroundJobAndNotificationsDemo.Emailing.Dto;

namespace BackgroundJobAndNotificationsDemo.Emailing
{
    public interface IPrivateEmailAppService : IApplicationService
    {
        Task Send(SendPrivateEmailInput input);
    }
}