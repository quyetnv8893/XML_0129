using System.Web;
using System.Web.Mvc;

namespace XML_0129_1008_QuyetNV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
