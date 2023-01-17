using System;
using Abp.Dependency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using MassTransit;
using MassTransitSample.Configuration;
using MassTransitSample.Orders.Dto;
using MassTransitSample.Web.Orders;

namespace MassTransitSample.Web.Startup
{
    [DependsOn(typeof(MassTransitSampleWebCoreModule))]
    public class MassTransitSampleWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MassTransitSampleWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MassTransitSampleNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MassTransitSampleWebMvcModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.IocContainer.Register(Component.For<OrderConsumer>().LifestyleTransient());
            
            var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri("rabbitmq://localhost/"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                config.ReceiveEndpoint(queueName: "repro-service", endpoint =>
                {
                    endpoint.Handler<OrderDto>(async context =>
                    {
                        using (var consumer = IocManager.ResolveAsDisposable<OrderConsumer>(typeof(OrderConsumer)))
                        {
                            await consumer.Object.Consume(context);
                        }
                    });
                });
            });

            IocManager.IocContainer.Register(Component.For<IBus, IBusControl>().Instance(busControl));

            busControl.Start();
        }
    }
}
