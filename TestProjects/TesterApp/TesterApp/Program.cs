using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abp.Threading;
using static TesterApp.LogHelper;

namespace TesterApp
{
    class Program
    {
        public enum TestType { Both, WithAbp, WithoutAbp };
        private static AbpTestService _abpTester;
        private static StandartTestService _standartTester;
        private static CountdownEvent _cdEvent;

        private static TesterAppCommandLineArgs _args;

        /// <summary>
        /// TesterApp.exe -a 0 -t 5 -r 10 -o "d:\testresult.txt"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _args = CommandLineArgs.Parse<TesterAppCommandLineArgs>(args);
            _abpTester = new AbpTestService();
            _standartTester = new StandartTestService();
            _cdEvent = new CountdownEvent(_args.ThreadCount);

            AsyncHelper.RunSync(() => RunAsync());
        }

        public static async Task RunAsync()
        {
            Log("\n" + DateTime.UtcNow + "\nThread Count = " + _args.ThreadCount + "\n", "Repeat Count = " + _args.RepeatCount + "\n");

            if (_args.TestType == (int)TestType.Both || _args.TestType == (int)TestType.WithAbp)
            {
                await TestThatMethod(TestInsertGetDeletefromDatabase, _abpTester);
                await TestThatMethod(TestGetConstant, _abpTester);

            }

            if (_args.TestType == (int)TestType.Both || _args.TestType == (int)TestType.WithoutAbp)
            {
                await TestThatMethod(TestInsertGetDeletefromDatabase, _standartTester);
                await TestThatMethod(TestGetConstant, _standartTester);
                
            }

            if (_args.TestType == (int)TestType.Both)
            {
                new ResultAnalyzer(_abpTester.Results,_standartTester.Results).AnalyzeResults();
            }


            Console.ReadLine();
        }

        static async Task TestThatMethod(Func<TestService, Task> testFunction, TestService testService)
        {
            for (int i = 0; i < _args.ThreadCount; i++)
            {
                new Thread(() =>
                {
                    AsyncHelper.RunSync(() => testFunction(testService));
                }).Start();
            }

            WaitThreads();
        }

        static async Task TestInsertGetDeletefromDatabase(TestService testService)
        {
            var idList = await testService.InsertAndGetId_Timer(_args.RepeatCount);
            await testService.Delete_Timer(idList);
            await testService.GetPeople_Timer(_args.RepeatCount);
            _cdEvent.Signal();
        }

        static async Task TestGetConstant(TestService testService)
        {
            await testService.GetConstant_Timer(_args.RepeatCount);
            _cdEvent.Signal();
        }
        public static void EvaluateResults(List<TestResult> results, string withOrWithoutAbp)
        {
            foreach (var result in results)
            {
                Log(result.Success
                    ? SuccessfullLogGenerator(result.Method, result.Duration, withOrWithoutAbp)
                    : UnsuccessfullLogGenerator(result.ErrorMessage, withOrWithoutAbp));
            }
        }

        public static void EvaluateResult(List<TestResult> results, string withOrWithoutAbp)
        {
            foreach (var result in results)
            {
                Log(result.Success
                    ? SuccessfullLogGenerator(result.Method, result.Duration, withOrWithoutAbp)
                    : UnsuccessfullLogGenerator(result.ErrorMessage, withOrWithoutAbp));
            }
        }

        public static void EvaluateErrors(List<TestResult> results, string withOrWithoutAbp)
        {
            var count = results.Count;
            var errorCount = results.Count(r => !r.Success);
            Log(ErrorCountLogGenerator(count, errorCount, withOrWithoutAbp)); 
        }

        public static void EvaluateAvarageSeconds(List<TestResult> results, string withOrWithoutAbp)
        {
            var averageGetPeople = results.Where(r => r.Success && r.Method == "GetPeople").Average(r => r.Duration.TotalSeconds);
            var averageGetConstant = results.Where(r => r.Success && r.Method == "GetConstant").Average(r => r.Duration.TotalSeconds);
            var averageDelete = results.Where(r => r.Success && r.Method == "Delete").Average(r => r.Duration.TotalSeconds);
            var averageInsertAndGetId = results.Where(r => r.Success && r.Method == "InsertAndGetId").Average(r => r.Duration.TotalSeconds);

            Log(AvarageCountLogGenerator(averageGetPeople, averageGetConstant, averageDelete, averageInsertAndGetId, withOrWithoutAbp));
        }

        public static string ErrorCountLogGenerator(int abpCount, int abpErrorCount, string withOrWithoutAbp)
        {
            return "Result: \n Error Rate " + withOrWithoutAbp + "ABP => " + abpErrorCount + "/" + abpCount + "\n ";

        }

        public static string AvarageCountLogGenerator(double averageGetPeople, double averageGetConstant, double averageDelete, double averageInsertAndGetId, string withOrWithoutAbp)
        {
            return "Avarage InsertAndGetId " + withOrWithoutAbp + " => " + averageInsertAndGetId + "   (" + (1 / averageInsertAndGetId) + " per second)\n" +
                   "Avarage Delete " + withOrWithoutAbp + " => " + averageDelete + "   (" + (1 / averageDelete) + " per second)\n" +
                   "Avarage GetPeople " + withOrWithoutAbp + " => " + averageGetPeople + "   (" + (1 / averageGetPeople) + " per second)\n" +
                   "Avarage GetConstant " + withOrWithoutAbp + " => " + averageGetConstant + "   (" + (1 / averageGetConstant) + " per second)\n";
        }

        public static string SuccessfullLogGenerator(string methodType, TimeSpan elapsedTime, string withOrWithoutAbp)
        {
            return "(" + withOrWithoutAbp + " ) -> SUCCESSFUL.  Time elapsed For " + methodType + ": " + elapsedTime.TotalSeconds / _args.RepeatCount + "(Avg), " + elapsedTime.TotalSeconds + " (Total)";
        }

        public static string UnsuccessfullLogGenerator(string message, string withOrWithoutAbp)
        {
            return "(" + withOrWithoutAbp + " ) -> FAILED. " + message;
        }

        public static void WaitThreads()
        {
            _cdEvent.Wait();
            _cdEvent.Reset();
        }
    }

}