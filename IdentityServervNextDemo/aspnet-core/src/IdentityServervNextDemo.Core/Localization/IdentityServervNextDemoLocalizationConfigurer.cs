using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdentityServervNextDemo.Localization
{
    public static class IdentityServervNextDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(IdentityServervNextDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IdentityServervNextDemoLocalizationConfigurer).GetAssembly(),
                        "IdentityServervNextDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
