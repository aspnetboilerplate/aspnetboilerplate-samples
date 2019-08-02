using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HealthCheckExample.Localization
{
    public static class HealthCheckExampleLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HealthCheckExampleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HealthCheckExampleLocalizationConfigurer).GetAssembly(),
                        "HealthCheckExample.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
