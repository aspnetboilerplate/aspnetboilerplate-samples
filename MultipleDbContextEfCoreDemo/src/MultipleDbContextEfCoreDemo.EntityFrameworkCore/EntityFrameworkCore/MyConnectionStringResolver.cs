using System;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.Extensions.Configuration;
using MultipleDbContextEfCoreDemo.Configuration;
using Abp.Reflection.Extensions;
using Abp.Runtime;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore;

public class MyConnectionStringResolver : DefaultConnectionStringResolver
{
    private readonly IConfigurationRoot _appConfiguration;
    private readonly IAmbientDataContext _ambientDataContext;

    public MyConnectionStringResolver(IAbpStartupConfiguration configuration, IAmbientDataContext ambientDataContext)
        : base(configuration)
    {
        _appConfiguration = AppConfigurations.Get(
            typeof(MyConnectionStringResolver).GetAssembly().GetDirectoryPathOrNull(),
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        );
        _ambientDataContext = ambientDataContext;
    }

    public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
    {
        if (args["DbContextConcreteType"] as Type == typeof(PlaygroundSecondDbContext))
        {
            return _appConfiguration.GetConnectionString(PlaygroundConsts.SecondDbConnectionStringName);
        }

        return base.GetNameOrConnectionString(args);
    }
}
