using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Acme.HeroShop.Localization
{
    public static class HeroShopLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HeroShopConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HeroShopLocalizationConfigurer).GetAssembly(),
                        "Acme.HeroShop.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
