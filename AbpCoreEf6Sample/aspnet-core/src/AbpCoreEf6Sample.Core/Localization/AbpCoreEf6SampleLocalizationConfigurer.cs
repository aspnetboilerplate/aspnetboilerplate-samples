using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpCoreEf6Sample.Localization
{
    public static class AbpCoreEf6SampleLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpCoreEf6SampleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpCoreEf6SampleLocalizationConfigurer).GetAssembly(),
                        "AbpCoreEf6Sample.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
