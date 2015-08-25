using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Modules;
using Abp.Threading;
using Abp.Web.Models;
using Abp.WebApi;
using Abp.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CallApiFromConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var bootstrapper = new AbpBootstrapper())
                {
                    bootstrapper.Initialize();

                    using (var client = bootstrapper.IocManager.ResolveAsDisposable<MyTestClient>())
                    {
                        Console.Write("Enter tenancy (demo) name: ");
                        client.Object.TenancyName = Console.ReadLine();
                        if (client.Object.TenancyName.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.Write("Enter username: ");
                        client.Object.UserName = Console.ReadLine();
                        if (client.Object.UserName.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.Write("Enter password: ");
                        client.Object.Password = Console.ReadLine();
                        if (client.Object.Password.IsNullOrWhiteSpace())
                        {
                            return;
                        }

                        Console.WriteLine("Logging in...");
                        
                        client.Object.Login();

                        Console.WriteLine("Getting roles...");

                        var roles = AsyncHelper.RunSync(() => client.Object.GetRolesAsync());

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

    [DependsOn(typeof(AbpWebApiModule))]
    public class MyModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class MyTestClient : ITransientDependency
    {
        public string TenancyName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string BaseUrl
        {
            get { return "http://" + TenancyName + ".demo.aspnetzero.com/"; }
        }

        private readonly IAbpWebApiClient _abpWebApiClient;

        public MyTestClient(IAbpWebApiClient abpWebApiClient)
        {
            _abpWebApiClient = abpWebApiClient;
        }

        public void Login()
        {
            var cookies = LoginAndGetCookies(BaseUrl + "Account/Login", TenancyName, UserName, Password);
            foreach (Cookie cookie in cookies)
            {
                _abpWebApiClient.Cookies.Add(cookie);
            }
        }

        public async Task<ListResultOutput<RoleListDto>> GetRolesAsync()
        {
            return await _abpWebApiClient.PostAsync<ListResultOutput<RoleListDto>>(
                BaseUrl + "api/services/app/role/GetRoles"
                );
        }

        private static CookieCollection LoginAndGetCookies(string url, string tenancyName, string userName, string password)
        {
            var requestBytes = Encoding.UTF8.GetBytes("TenancyName=" + tenancyName + "&UsernameOrEmailAddress=" + userName + "&Password=" + password);

            var request = WebRequest.CreateHttp(url);

            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "application/json";
            request.CookieContainer = new CookieContainer();
            request.ContentLength = requestBytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Flush();

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseString = Encoding.UTF8.GetString(response.GetResponseStream().GetAllBytes());
                    var ajaxResponse = JsonString2Object<AjaxResponse>(responseString);

                    if (!ajaxResponse.Success)
                    {
                        throw new Exception("Could not login. Reason: " + ajaxResponse.Error.Message + " | " + ajaxResponse.Error.Details);
                    }

                    return response.Cookies;
                }
            }
        }

        private static TObj JsonString2Object<TObj>(string str)
        {
            return JsonConvert.DeserializeObject<TObj>(str,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }

    public class RoleListDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
