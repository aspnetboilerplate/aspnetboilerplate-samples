using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdentityServerDemo.SSO.Localization
{
    public static class SSOLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SSOConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SSOLocalizationConfigurer).GetAssembly(),
                        "IdentityServerDemo.SSO.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
