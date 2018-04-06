using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Acme.MySqlDemo.Localization
{
    public static class MySqlDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MySqlDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MySqlDemoLocalizationConfigurer).GetAssembly(),
                        "Acme.MySqlDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
