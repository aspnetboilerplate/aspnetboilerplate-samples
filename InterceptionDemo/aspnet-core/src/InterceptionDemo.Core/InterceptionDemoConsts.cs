using InterceptionDemo.Debugging;

namespace InterceptionDemo
{
    public class InterceptionDemoConsts
    {
        public const string LocalizationSourceName = "InterceptionDemo";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "463c3f4bdfb048758b76d8fce04a101a";
    }
}
