using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SimpleTaskSystem.Localization
{
    public static class SimpleTaskSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SimpleTaskSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SimpleTaskSystemLocalizationConfigurer).GetAssembly(),
                        "SimpleTaskSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
