using IdentityServer4.EntityFramework.Options;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer
{
    public class IdentityServerStoreOptionsProvider
    {
        public static IdentityServerStoreOptionsProvider Instance { get; } = new IdentityServerStoreOptionsProvider();

        public ConfigurationStoreOptions ConfigurationStoreOptions { get; }
        public OperationalStoreOptions OperationalStoreOptions { get; }

        public IdentityServerStoreOptionsProvider()
        {
            //Config your store options here.
            ConfigurationStoreOptions = new ConfigurationStoreOptions();
            OperationalStoreOptions = new OperationalStoreOptions();
        }
    }
}
