using System;
using System.Threading.Tasks;
using Abp.Web.Models;
using Newtonsoft.Json;

namespace TesterApp
{
    public class AbpTestService : TestService
    {
        private const string BaseAddress = "http://localhost:62114/Home/";

        public AbpTestService()
            : base(BaseAddress)
        {
            
        }

        public override async Task GetPeople()
        {
            var response = await Client.GetAsync("GetList");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public override async Task GetConstant()
        {
            var response = await Client.GetAsync("GetConstant");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public override async Task Delete(int id)
        {
            var response = await Client.DeleteAsync($"Delete?id={id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public override async Task<int> InsertAndGetId(string name, string phoneNumber)
        {
            var response = await Client.GetAsync($"InsertAndGetId?name={name}&phoneNumber={phoneNumber}");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<AjaxResponse<int>>(str);
                return obj.Result;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
