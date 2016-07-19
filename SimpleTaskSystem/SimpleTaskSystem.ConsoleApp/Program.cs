using System;
using Abp;
using Abp.Dependency;

namespace SimpleTaskSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<SimpleTaskSystemConsoleAppModule>())
            {
                bootstrapper.Initialize();

                Test_Way_1(bootstrapper.IocManager);
                Test_Way_2(bootstrapper.IocManager);
                Test_Way_3(bootstrapper.IocManager);
            }

            Console.ReadLine();
        }

        private static void Test_Way_1(IIocManager iocManager)
        {
            var tester = iocManager.Resolve<Tester>();

            tester.Test();

            iocManager.Release(tester);
        }

        private static void Test_Way_2(IIocManager iocManager)
        {
            using (var tester = iocManager.ResolveAsDisposable<Tester>())
            {
                tester.Object.Test();
            }
        }

        private static void Test_Way_3(IIocManager iocManager)
        {
            iocManager.Using<Tester>(tester =>
            {
                tester.Test();
            });
        }
    }
}
