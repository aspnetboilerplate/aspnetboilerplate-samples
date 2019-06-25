using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Json;
using Abp.Web.Models;
using IdentityModel.Client;
using IdentityServerDemo.Users.Dto;
using Newtonsoft.Json;

namespace IdentityServerDemo.ConsoleApiTester
{
    class Program
    {
        private const string ServerUrlBase = "http://localhost:62114/";

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
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(ServerUrlBase);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            client.DefaultRequestHeaders.Add("Abp.TenantId", "1");  //Set TenantId
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "def2edf7-5d42-4edc-a84a-30136c340e13",

                Scope = "default-api",

                UserName = "admin",
                Password = "123qwe"
            });

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

            var response = await client.GetAsync($"{ServerUrlBase}api/services/app/user/getUsers");
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