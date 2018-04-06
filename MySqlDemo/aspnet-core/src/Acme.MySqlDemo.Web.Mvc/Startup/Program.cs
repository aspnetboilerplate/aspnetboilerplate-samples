using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Acme.MySqlDemo.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitWebHost(args).Run();
        }

        public static IWebHost InitWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
