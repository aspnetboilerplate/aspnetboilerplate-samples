using System;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Web;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public class MyConnectionStringResolver : DefaultConnectionStringResolver
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyConnectionStringResolver(IAbpStartupConfiguration configuration,IHostingEnvironment hostingEnvironment) 
            : base(configuration)
        {
            _appConfiguration =
                AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args["DbContextConcreteType"] as Type == typeof(MultipleDbContextEfCoreDemoSecondDbContext))
            {
                return _appConfiguration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondDbConnectionStringName);
            }

            return base.GetNameOrConnectionString(args);
        }
    }
}