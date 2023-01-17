using MassTransitSample.Debugging;

namespace MassTransitSample
{
    public class MassTransitSampleConsts
    {
        public const string LocalizationSourceName = "MassTransitSample";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5a793a7704454882ac16c24e4cc47202";
    }
}
