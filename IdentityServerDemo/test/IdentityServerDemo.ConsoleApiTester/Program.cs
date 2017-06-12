using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Json;
using Abp.MultiTenancy;
using Abp.Web.Models;
using IdentityModel.Client;
using IdentityServerDemo.Users.Dto;
using Newtonsoft.Json;

namespace IdentityServerDemo.ConsoleApiTester
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDemoAsync().Wait();
            Console.ReadLine();
        }

        public static async Task RunDemoAsync()
        {
            var accessToken = await GetAccessTokenViaOwnerPasswordAsync();
            await GetUsersListAsync(accessToken);
        }

        private static async Task<string> GetAccessTokenViaOwnerPasswordAsync()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:62114");

            var httpHandler = new HttpClientHandler();
            httpHandler.CookieContainer.Add(new Uri("http://localhost:62114/"), new Cookie(MultiTenancyConsts.TenantIdResolveKey, "1")); //Set TenantId
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret", httpHandler);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("admin", "123qwe");

            if (tokenResponse.IsError)
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse.AccessToken;
        }

        private static async Task GetUsersListAsync(string accessToken)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("http://localhost:62114/api/services/app/user/getUsers");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }

            var content = await response.Content.ReadAsStringAsync();
            var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse<PagedResultDto<UserListDto>>>(content);
            if (!ajaxResponse.Success)
            {
                throw new Exception(ajaxResponse.Error?.Message ?? "Remote service throws exception!");
            }

            Console.WriteLine();
            Console.WriteLine("Total user count: " + ajaxResponse.Result.TotalCount);
            Console.WriteLine();
            foreach (var user in ajaxResponse.Result.Items)
            {
                Console.WriteLine($"### UserId: {user.Id}, UserName: {user.UserName}");
                Console.WriteLine(user.ToJsonString(indented: true));
            }
        }
    }
}