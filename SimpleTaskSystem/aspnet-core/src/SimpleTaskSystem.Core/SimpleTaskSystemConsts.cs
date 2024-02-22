using SimpleTaskSystem.Debugging;

namespace SimpleTaskSystem
{
    public class SimpleTaskSystemConsts
    {
        public const string LocalizationSourceName = "SimpleTaskSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "44cca5aef5d845f885bf9b15f2378acd";
    }
}
