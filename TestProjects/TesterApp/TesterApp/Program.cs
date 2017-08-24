using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abp.Threading;
using static TesterApp.LogHelper;
using static TesterApp.Program.TestType;

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

            if (_args.TestType == (int)Both || _args.TestType == (int)WithAbp)
            {
                await TestThatMethod(TestInsertGetDeletefromDatabase, _abpTester);
                await TestThatMethod(TestGetConstant, _abpTester);

            }

            if (_args.TestType == (int)Both || _args.TestType == (int)WithoutAbp)
            {
                await TestThatMethod(TestInsertGetDeletefromDatabase, _standartTester);
                await TestThatMethod(TestGetConstant, _standartTester);
                
            }
            
             new ResultAnalyzer(_abpTester.Results,_standartTester.Results).AnalyzeResults(_args.TestType);


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
        
        public static void WaitThreads()
        {
            _cdEvent.Wait();
            _cdEvent.Reset();
        }
    }

}