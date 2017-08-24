using System;
using System.IO;
using Abp.Collections.Extensions;

namespace TesterApp
{
    public class TesterAppCommandLineArgs : CommandLineArgs
    {
        public int ThreadCount => Convert.ToInt32(this.GetOrDefault("t") ?? "5");
        public int TestType => Convert.ToInt32(this.GetOrDefault("a") ?? "0");
        public int RepeatCount => Convert.ToInt32(this.GetOrDefault("r") ?? "10");

        public string OutputFilePath
        {
            get
            {
                var output = this.GetOrDefault("o") ?? LogHelper.DefaultOutputFilePath;
                return Path.IsPathRooted(output)
                    ? output
                    : Path.Combine(Directory.GetCurrentDirectory(), output);
            }
        }
    }
}