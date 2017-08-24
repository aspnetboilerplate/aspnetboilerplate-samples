using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp;
using Abp.Threading.Extensions;

namespace TesterApp
{
    public abstract class TestService
    {
        public List<TestResult> Results { get; }

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

        public async Task GetPeople_Timer(int repeat)
        {
            for (var i = 0; i < repeat; i++)
            {
                var result = new TestResult { Method = "GetPeople" };
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
                    Results.Locking(r => r.Add(result));
                }
            }
        }

        public async Task GetConstant_Timer(int repeat)
        {
            for (var i = 0; i < repeat; i++)
            {
                var result = new TestResult { Method = "GetConstant" };
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    await GetConstant();
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
                    Results.Locking(r => r.Add(result));
                }
            }
        }

        public async Task Delete_Timer(List<int> idList)
        {
            foreach (var id in idList)
            {
                var result = new TestResult { Method = "Delete" };
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    await Delete(id);
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
                    Results.Locking(r => r.Add(result));
                }
            }
        }

        public async Task<List<int>> InsertAndGetId_Timer(int repeat)
        {
            var idList = new List<int>();

            for (var i = 0; i < repeat; i++)
            {
                var result = new TestResult { Method = "InsertAndGetId" };
                var randomString = RandomString(15);
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    var id = await InsertAndGetId(randomString, "666666");
                    idList.Add(id);
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
                    Results.Locking(r => r.Add(result));
                }
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
