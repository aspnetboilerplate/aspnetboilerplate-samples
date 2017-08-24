using System;
using System.IO;
using System.Threading;

namespace TesterApp
{
    public static class LogHelper
    {
        public const string DefaultOutputFilePath = "TesterApp-Output.txt";

        public static string OutputFilePath = DefaultOutputFilePath;

        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        public static void Log(params string[] results)
        {
            Lock.EnterWriteLock();
            try
            {
                File.AppendAllLines(OutputFilePath, results);

                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }
}
