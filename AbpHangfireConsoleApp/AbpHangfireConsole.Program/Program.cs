﻿using System;
using AbpHangfireConsole.Hangfire.Jobs.GetServers;
using AbpHangfireConsole.Hangfire.Jobs.GetServers.Dtos;
using Hangfire;
using Microsoft.Owin.Hosting;

namespace AbpHangfireConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AbpHangfireConsoleApplication<AbpHangfireConsoleProgramModule> application = new AbpHangfireConsoleApplication<AbpHangfireConsoleProgramModule>();

            try
            {
                application.Application_Start();

                using (WebApp.Start<Startup>("http://127.0.0.1:8111"))
                {
                    Console.WriteLine("Hangfire Server started on http://127.0.0.1:8111/hangfire");
                    Console.WriteLine("");
                    Console.WriteLine("In 10s the job GetServersJob will execute.");
                    Console.WriteLine("");
                    //Kick off a sample job for 10 seconds from now
                    BackgroundJob.Schedule<GetServersJob>(x => x.ExecuteJob(null, new GetServersParamsInput()), TimeSpan.FromSeconds(10));
                    Console.WriteLine("Wait for the job to execute. Otherwise press any key to terminate....");

                    Console.ReadKey();
                }
            }
            finally
            {
                application.Application_End();
            }
        }
    }
}
