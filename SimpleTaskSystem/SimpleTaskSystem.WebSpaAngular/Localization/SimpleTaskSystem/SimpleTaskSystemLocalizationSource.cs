using System.Web;
using Abp.Localization.Sources.Xml;

namespace SimpleTaskSystem.WebSpaAngular.Localization.SimpleTaskSystem
{
    public class SimpleTaskSystemLocalizationSource : XmlLocalizationSource
    {
        public SimpleTaskSystemLocalizationSource()
            : base("SimpleTaskSystem", HttpContext.Current.Server.MapPath("/Localization/SimpleTaskSystem"))
        {
        }
    }
}