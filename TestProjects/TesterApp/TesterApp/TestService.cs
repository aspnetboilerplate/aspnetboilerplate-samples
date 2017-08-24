using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp;

namespace TesterApp
{
    public abstract class TestService
    {
        public List<TestResult> Results { get; set; }

        public HttpClient Client { get; }

        public abstract Task GetPeople();

        public abstract Task GetConstant();

        public abstract Task Delete(int id);

        public abstract Task<int> InsertAndGetId(string name, string phoneNumber);

        protected TestService(string baseAddress)
        {
            Client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Results = new List<TestResult>();
        }

        public async Task GetPeople_Timer()
        {
            var result = new TestResult {Method = "GetPeople"};
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await GetPeople();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                stopwatch.Stop();
                result.Duration = stopwatch.Elapsed;
                Results.Add(result);
            }
        }

        public async Task GetConstant_Timer(int repeat)
        {
            var result = new TestResult { Method = "GetConstant" };
            var stopwatch = Stopwatch.StartNew();

            try
            {
                for (int i = 0; i < repeat; i++)
                {
                    await GetConstant();
                }
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                stopwatch.Stop();
                result.Duration = stopwatch.Elapsed;
                Results.Add(result);
            }
        }

        public async Task Delete_Timer(List<int> idList)
        {
            var result = new TestResult { Method = "Delete" };
            var stopwatch = Stopwatch.StartNew();

            try
            {
                foreach (var id in idList)
                {
                    await Delete(id);
                }
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                stopwatch.Stop();
                result.Duration = stopwatch.Elapsed;
                Results.Add(result);
            }
        }

        public async Task<List<int>> InsertAndGetId_Timer(int repeat)
        {
            var idList = new List<int>();
            var result = new TestResult { Method = "InsertAndGetId" };
            var stopwatch = Stopwatch.StartNew();

            try
            {
                for (int i = 0; i < repeat; i++)
                {
                    var id = await InsertAndGetId(RandomString(15), "666666");
                    idList.Add(id);
                }
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                stopwatch.Stop();
                result.Duration = stopwatch.Elapsed;
                Results.Add(result);
            }
            return idList;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[RandomHelper.GetRandom(s.Length)]).ToArray());
        }
        
    }
}
