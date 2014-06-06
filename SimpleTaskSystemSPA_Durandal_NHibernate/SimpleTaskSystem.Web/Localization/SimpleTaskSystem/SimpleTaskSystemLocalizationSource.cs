using System.Web;
using Abp.Dependency;
using Abp.Localization.Sources.Xml;

namespace SimpleTaskSystem.Web.Localization.SimpleTaskSystem
{
    public class SimpleTaskSystemLocalizationSource : XmlLocalizationSource
    {
        public SimpleTaskSystemLocalizationSource()
            : base("SimpleTaskSystem", HttpContext.Current.Server.MapPath("/Localization/SimpleTaskSystem"))
        {
        }
    }
}