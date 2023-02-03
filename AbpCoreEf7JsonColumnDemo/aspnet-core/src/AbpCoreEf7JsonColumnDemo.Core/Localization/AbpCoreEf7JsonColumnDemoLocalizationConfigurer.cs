using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpCoreEf7JsonColumnDemo.Localization
{
    public static class AbpCoreEf7JsonColumnDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpCoreEf7JsonColumnDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpCoreEf7JsonColumnDemoLocalizationConfigurer).GetAssembly(),
                        "AbpCoreEf7JsonColumnDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
