using System;
using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;

namespace DatabaseMaintainer
{
    public class DeleteOldAuditLogsWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;

        public DeleteOldAuditLogsWorker(AbpTimer timer, IRepository<AuditLog, long> auditLogRepository)
            : base(timer)
        {
            _auditLogRepository = auditLogRepository;
            Timer.Period = 5000;
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            Logger.Info("DeleteOldAuditLogsWorker is working...");

            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var oneMonthAgo = Clock.Now.Subtract(TimeSpan.FromDays(30));

                _auditLogRepository.Delete(log => log.ExecutionTime < oneMonthAgo);

                CurrentUnitOfWork.SaveChanges();
            }
        }
    }
}