using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace InterceptionDemo.Localization
{
    public static class InterceptionDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(InterceptionDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(InterceptionDemoLocalizationConfigurer).GetAssembly(),
                        "InterceptionDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
