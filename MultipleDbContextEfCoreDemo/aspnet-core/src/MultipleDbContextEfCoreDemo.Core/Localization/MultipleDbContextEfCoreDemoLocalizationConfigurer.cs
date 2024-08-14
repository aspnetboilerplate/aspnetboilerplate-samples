using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MultipleDbContextEfCoreDemo.Localization
{
    public static class MultipleDbContextEfCoreDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MultipleDbContextEfCoreDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MultipleDbContextEfCoreDemoLocalizationConfigurer).GetAssembly(),
                        "MultipleDbContextEfCoreDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
