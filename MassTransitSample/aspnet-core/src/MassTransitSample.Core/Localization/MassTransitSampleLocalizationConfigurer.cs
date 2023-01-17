using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MassTransitSample.Localization
{
    public static class MassTransitSampleLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MassTransitSampleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MassTransitSampleLocalizationConfigurer).GetAssembly(),
                        "MassTransitSample.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
