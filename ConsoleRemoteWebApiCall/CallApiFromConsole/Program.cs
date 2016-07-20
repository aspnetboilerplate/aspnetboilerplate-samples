using System;
using Abp;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Threading;
using Abp.WebApi.Client;

namespace CallApiFromConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("See https://github.com/aspnetboilerplate/aspnetboilerplate-samples/tree/master/ConsoleRemoteWebApiCall to know how to use this demo application.");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
            try
            {
                using (var bootstrapper = AbpBootstrapper.Create<MyModule>())
                {
                    bootstrapper.Initialize();

                    using (var testClient = bootstrapper.IocManager.ResolveAsDisposable<MyTestClient>())
                    {
                        Console.Write("Enter tenancy (demo) name: ");
                        testClient.Object.TenancyName = Console.ReadLine();
                        if (testClient.Object.TenancyName.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.Write("Enter username: ");
                        testClient.Object.UserName = Console.ReadLine();
                        if (testClient.Object.UserName.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.Write("Enter password: ");
                        testClient.Object.Password = Console.ReadLine();
                        if (testClient.Object.Password.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.Write("Cookie based (C) or Token based (T) auth (default: C)?");
                        var authType = Console.ReadLine() ?? "C";
                        
                        if (authType.ToUpperInvariant() == "T")
                        {
                            Console.WriteLine("Logging in with TOKEN based auth...");
                            testClient.Object.TokenBasedAuth();
                        }
                        else
                        {
                            Console.WriteLine("Logging in with COOKIE based auth...");
                            testClient.Object.CookieBasedAuth();
                        }

                        Console.WriteLine("Getting roles...");

                        var roles = AsyncHelper.RunSync(() => testClient.Object.GetRolesAsync());

                        Console.WriteLine(roles.Items.Count + " roles found:");
                        foreach (var role in roles.Items)
                        {
                            Console.WriteLine("Role: Id=" + role.Id + ", DisplayName=" + role.DisplayName + ", IsDefault=" + role.IsDefault);
                        }
                    }
                }
            }
            catch (AbpRemoteCallException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
