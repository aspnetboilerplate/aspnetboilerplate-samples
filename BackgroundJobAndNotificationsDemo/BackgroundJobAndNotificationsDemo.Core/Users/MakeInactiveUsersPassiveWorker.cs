using System;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;

namespace BackgroundJobAndNotificationsDemo.Users
{
    /// <summary>
    /// A sample background worker to make a user passive if he/she did not login in last 30 days.
    /// </summary>
    public class MakeInactiveUsersPassiveWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IRepository<User, long> _userRepository;

        public MakeInactiveUsersPassiveWorker(AbpTimer timer, IRepository<User, long> userRepository)
            : base(timer)
        {
            _userRepository = userRepository;
            Timer.Period = 5000; //5 seconds (good for tests, but normally will be more)
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var oneMonthAgo = Clock.Now.Subtract(TimeSpan.FromDays(30));

                var inactiveUsers = _userRepository.GetAllList(u =>
                    u.IsActive &&
                    ((u.LastLoginTime < oneMonthAgo && u.LastLoginTime != null) || (u.CreationTime < oneMonthAgo && u.LastLoginTime == null))
                    );

                foreach (var inactiveUser in inactiveUsers)
                {
                    inactiveUser.IsActive = false;
                    Logger.Info(inactiveUser + " made passive since he/she did not login in last 30 days.");
                }

                CurrentUnitOfWork.SaveChanges();
            }
        }
    }
}
