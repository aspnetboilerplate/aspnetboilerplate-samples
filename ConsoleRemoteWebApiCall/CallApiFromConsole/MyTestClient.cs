using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Extensions;
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
            TokenBasedAuth(BaseUrl + "api/TokenAuth/Authenticate");
        }

        public async Task<ListResultOutput<RoleListDto>> GetRolesAsync()
        {
            return await GetAsync<ListResultOutput<RoleListDto>>(
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
            var result = AsyncHelper.RunSync(() =>
                _abpWebApiClient.PostAsync<AuthenticateResultDto>(
                    url,
                    new
                    {
                        TenancyName = TenancyName,
                        UsernameOrEmailAddress = UserName,
                        Password = Password
                    }));

            _abpWebApiClient.RequestHeaders.Add(new NameValue("Authorization", "Bearer " + result.AccessToken));

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

        private async Task<TResult> GetAsync<TResult>(string url, object input, int? timeout = null)
            where TResult : class
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = timeout.HasValue ? TimeSpan.FromMilliseconds(timeout.Value) : TimeSpan.FromSeconds(90);

                    if (!BaseUrl.IsNullOrEmpty())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                    }

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    foreach (var header in _abpWebApiClient.RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }

                    using (var requestContent = new StringContent(Object2JsonString(input), Encoding.UTF8, "application/json"))
                    {
                        foreach (var cookie in _abpWebApiClient.Cookies)
                        {
                            if (!BaseUrl.IsNullOrEmpty())
                            {
                                cookieContainer.Add(new Uri(BaseUrl), cookie);
                            }
                            else
                            {
                                cookieContainer.Add(cookie);
                            }
                        }

                        using (var response = await client.GetAsync(url + "?" + Object2QueryString(requestContent)))
                        {
                            if (!response.IsSuccessStatusCode)
                            {
                                throw new AbpException("Could not made request to " + url + "! StatusCode: " + response.StatusCode + ", ReasonPhrase: " + response.ReasonPhrase);
                            }

                            var ajaxResponse = JsonString2Object<AjaxResponse<TResult>>(await response.Content.ReadAsStringAsync());
                            if (!ajaxResponse.Success)
                            {
                                throw new AbpRemoteCallException(ajaxResponse.Error);
                            }

                            return ajaxResponse.Result;
                        }
                    }
                }
            }
        }

        private string Object2QueryString(StringContent requestContent)
        {
            var properties = from p in requestContent.GetType().GetProperties()
                             where p.GetValue(requestContent, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestContent, null).ToString());

            return String.Join("&", properties.ToArray());
        }

        private static string Object2JsonString(object obj)
        {
            if (obj == null)
            {
                return "";
            }

            return JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
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