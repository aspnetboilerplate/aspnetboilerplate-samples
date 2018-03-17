using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Volo.PostgreSqlDemo.Localization
{
    public static class PostgreSqlDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PostgreSqlDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PostgreSqlDemoLocalizationConfigurer).GetAssembly(),
                        "Volo.PostgreSqlDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
