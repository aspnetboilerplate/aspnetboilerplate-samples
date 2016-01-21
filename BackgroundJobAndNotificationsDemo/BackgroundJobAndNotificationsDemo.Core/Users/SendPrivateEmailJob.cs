using System;
using Abp;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace BackgroundJobAndNotificationsDemo.Users
{
    public class SendPrivateEmailJob : BackgroundJob<SendPrivateEmailJobArgs>, ITransientDependency
    {
        private readonly IRepository<User, long> _userRepository;

        public SendPrivateEmailJob(IRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        [UnitOfWork]
        public override void Execute(SendPrivateEmailJobArgs args)
        {
            //A simulation of exceptions
            if (RandomHelper.GetRandom(0, 100) < 50)
            {
                throw new Exception("Random exception!");
            }

            using (CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, args.TargetTenantId))
            {
                var user = _userRepository.FirstOrDefault(args.TargetUserId);
                if (user == null)
                {
                    Logger.WarnFormat("Unknown userId: {0}. Can not execute job!", args.TargetUserId);
                    return;
                }

                //Here, we should actually send the email! We can inject and use IEmailSender for example.
                Logger.Info("Sending email to " + user.EmailAddress + " -> " + args.Subject);
                Logger.Info(args.Body);
            }
        }
    }
}
