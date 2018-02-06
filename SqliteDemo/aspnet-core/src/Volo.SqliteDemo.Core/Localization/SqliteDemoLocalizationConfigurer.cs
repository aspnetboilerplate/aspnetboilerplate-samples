using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Volo.SqliteDemo.Localization
{
    public static class SqliteDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SqliteDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SqliteDemoLocalizationConfigurer).GetAssembly(),
                        "Volo.SqliteDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
