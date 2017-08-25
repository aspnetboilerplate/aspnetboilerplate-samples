using System;
using System.Threading.Tasks;

namespace TesterApp
{
    public class StandartTestService : TestService
    {
        private const string BaseAddress = "http://localhost:55380/Home/";

        public StandartTestService()
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
                return Convert.ToInt32(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}
