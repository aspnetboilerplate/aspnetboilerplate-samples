using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using HealthCheckExample.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckExample.HealthChecks
{
    public class HealthCheckExampleDbContextCheck : IHealthCheck
    {
        private readonly IDbContextProvider<HealthCheckExampleDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public HealthCheckExampleDbContextCheck(
            IDbContextProvider<HealthCheckExampleDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            _dbContextProvider = dbContextProvider;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var uow = _unitOfWorkManager.Begin())
                {
                    if (await _dbContextProvider.GetDbContext().Database.CanConnectAsync(cancellationToken))
                    {
                        return HealthCheckResult.Healthy("HealthCheckExampleDbContext could connect to database");
                    }
                }
                return HealthCheckResult.Unhealthy("HealthCheckExampleDbContext could not connect to database");
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy("Error when trying to check HealthCheckExampleDbContext. ", e);
            }
        }
    }
}
