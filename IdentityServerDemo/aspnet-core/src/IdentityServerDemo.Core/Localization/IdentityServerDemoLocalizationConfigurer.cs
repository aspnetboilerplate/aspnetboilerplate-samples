using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdentityServerDemo.Localization
{
    public static class IdentityServerDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(IdentityServerDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IdentityServerDemoLocalizationConfigurer).GetAssembly(),
                        "IdentityServerDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
