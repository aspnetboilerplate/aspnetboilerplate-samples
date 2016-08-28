using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.IO.Extensions;
using Abp.Threading;
using Abp.Web.Models;
using Abp.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CallApiFromConsole
{
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

        public void CookieBasedAuth()
        {
            CookieBasedAuth(BaseUrl + "Account/Login");
        }

        public void TokenBasedAuth()
        {
            TokenBasedAuth(BaseUrl + "api/Account/Authenticate");
        }

        public async Task<ListResultOutput<RoleListDto>> GetRolesAsync()
        {
            return await _abpWebApiClient.PostAsync<ListResultOutput<RoleListDto>>(
                BaseUrl + "api/services/app/role/GetRoles",
                new GetRolesInput()
            );
        }

        private void CookieBasedAuth(string url)
        {
            var requestBytes = Encoding.UTF8.GetBytes("TenancyName=" + TenancyName + "&UsernameOrEmailAddress=" + UserName + "&Password=" + Password);

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

                    _abpWebApiClient.Cookies.Clear();
                    foreach (Cookie cookie in response.Cookies)
                    {
                        _abpWebApiClient.Cookies.Add(cookie);
                    }
                }
            }
        }
        
        private void TokenBasedAuth(string url)
        {
            var token = AsyncHelper.RunSync(() =>
                _abpWebApiClient.PostAsync<string>(
                    url,
                    new
                    {
                        TenancyName = TenancyName,
                        UsernameOrEmailAddress = UserName,
                        Password = Password
                    }));

            _abpWebApiClient.RequestHeaders.Add(new NameValue("Authorization", "Bearer " + token));

            #region Alternative implementation: Manual HTTP request

            //var requestBytes = Encoding.UTF8.GetBytes((new
            //{
            //    TenancyName = TenancyName,
            //    UsernameOrEmailAddress = UserName,
            //    Password = Password
            //}).ToJsonString());

            //var request = WebRequest.CreateHttp(url);

            //request.Method = WebRequestMethods.Http.Post;
            //request.ContentType = "application/json";
            //request.Accept = "application/json";
            //request.ContentLength = requestBytes.Length;

            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(requestBytes, 0, requestBytes.Length);
            //    stream.Flush();

            //    using (var response = (HttpWebResponse)request.GetResponse())
            //    {
            //        var responseString = Encoding.UTF8.GetString(response.GetResponseStream().GetAllBytes());
            //        var ajaxResponse = JsonString2Object<AjaxResponse>(responseString);

            //        if (!ajaxResponse.Success)
            //        {
            //            throw new Exception("Could not login. Reason: " + ajaxResponse.Error.Message + " | " + ajaxResponse.Error.Details);
            //        }

            //        var token = ajaxResponse.Result.ToString();
            //        _abpWebApiClient.RequestHeaders.Add(new NameValue("Authorization", "Bearer " + token));
            //    }
            //}

            #endregion
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
}