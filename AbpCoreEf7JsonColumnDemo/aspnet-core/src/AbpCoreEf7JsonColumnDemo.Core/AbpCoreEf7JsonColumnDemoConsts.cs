using AbpCoreEf7JsonColumnDemo.Debugging;

namespace AbpCoreEf7JsonColumnDemo
{
    public class AbpCoreEf7JsonColumnDemoConsts
    {
        public const string LocalizationSourceName = "AbpCoreEf7JsonColumnDemo";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "926b2cf93f7c4b6683a395412b8895d9";
    }
}
