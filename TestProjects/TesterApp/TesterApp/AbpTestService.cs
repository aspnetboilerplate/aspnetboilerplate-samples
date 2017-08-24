using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Newtonsoft.Json;

namespace TesterApp
{
    public class AbpTestService : TestService
    {
        private const string BaseAddressOfAppservice = "http://localhost:8080/api/services/app/Person/";
        private const string BaseAddress = "http://localhost:8080/Home/";

        public AbpTestService()
            : base(BaseAddress)
        {
            
        }

        public async Task<List<Person>> GetPeopleFromAppService()
        {
            var response = await Client.GetAsync("GetPeople");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var str = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<AjaxResponse<ListResultDto<Person>>>(str);

            return obj.Result.Items.ToList();
        }

        public async Task GetConstantFromAppService()
        {
            var response = await Client.GetAsync("GetConstant");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task DeleteFromAppService(int id)
        {
            var response = await Client.DeleteAsync($"Delete?id={id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<int> InsertAndGetIdFromAppService(string name, string phoneNumber)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(new InsertAndGetIdInput() { Name = name, PhoneNumber = phoneNumber }), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"InsertAndGetId", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<AjaxResponse<int>>(str);
                return obj.Result;
            }

            throw new Exception(response.ReasonPhrase);
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
