using System.Web;
using System.Web.Mvc;

namespace Contoso.Apps.SportsLeague.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
