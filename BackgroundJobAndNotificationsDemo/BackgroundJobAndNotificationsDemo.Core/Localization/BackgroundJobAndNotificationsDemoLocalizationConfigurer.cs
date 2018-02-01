using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BackgroundJobAndNotificationsDemo.Localization
{
    public static class BackgroundJobAndNotificationsDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BackgroundJobAndNotificationsDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BackgroundJobAndNotificationsDemoLocalizationConfigurer).GetAssembly(),
                        "BackgroundJobAndNotificationsDemo.Localization.Source"
                    )
                )
            );
        }
    }
}
