using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdentityServerWithEfCoreDemo.Localization
{
    public static class IdentityServerWithEfCoreDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(IdentityServerWithEfCoreDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IdentityServerWithEfCoreDemoLocalizationConfigurer).GetAssembly(),
                        "IdentityServerWithEfCoreDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
