using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpKendoDemo.Localization
{
    public static class AbpKendoDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpKendoDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpKendoDemoLocalizationConfigurer).GetAssembly(),
                        "AbpKendoDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
