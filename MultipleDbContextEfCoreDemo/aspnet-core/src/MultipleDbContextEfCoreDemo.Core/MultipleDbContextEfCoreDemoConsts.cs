using MultipleDbContextEfCoreDemo.Debugging;

namespace MultipleDbContextEfCoreDemo
{
    public class MultipleDbContextEfCoreDemoConsts
    {
        public const string LocalizationSourceName = "MultipleDbContextEfCoreDemo";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8a46b57e80be4054814bfd4aa94e7235";
    }
}
