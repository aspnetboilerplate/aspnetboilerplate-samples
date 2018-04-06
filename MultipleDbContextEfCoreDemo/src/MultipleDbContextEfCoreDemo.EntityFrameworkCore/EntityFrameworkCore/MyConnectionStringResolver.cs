using System;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.Extensions.Configuration;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Web;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public class MyConnectionStringResolver : DefaultConnectionStringResolver
    {
        public MyConnectionStringResolver(IAbpStartupConfiguration configuration) 
            : base(configuration)
        {
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args["DbContextConcreteType"] as Type == typeof(MultipleDbContextEfCoreDemoSecondDbContext))
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondDbConnectionStringName);
            }

            return base.GetNameOrConnectionString(args);
        }
    }
}