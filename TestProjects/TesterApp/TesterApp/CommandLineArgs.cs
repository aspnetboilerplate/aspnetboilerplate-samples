using System.Collections.Generic;

namespace TesterApp
{
    public class CommandLineArgs : Dictionary<string, string>
    {
        public static T Parse<T>(string[] args)
            where T : CommandLineArgs, new()
        {
            var dictionary = new T();

            for (var i = 0; i < args.Length / 2; i++)
            {
                var argName = args[i * 2].Substring(1);
                dictionary[argName] = args[i * 2 + 1];
            }

            return dictionary;
        }
    }
}