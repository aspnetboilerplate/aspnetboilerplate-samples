using System;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace IdentityServerWithEfCoreDemo.ConsoleApiClient
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
            var disco =  await new HttpClient().GetDiscoveryDocumentAsync("https://localhost:44388");

            var tokenClient = new HttpClient();
            tokenClient.DefaultRequestHeaders.Add("Abp.TenantId", "1");
            var tokenResponse = await tokenClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
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

            var response = await client.GetAsync("https://localhost:44388/api/services/app/user/GetAll");
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
                Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
            }
        }
    }

    internal class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
