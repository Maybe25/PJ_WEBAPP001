using System.Web;
using System.Web.Mvc;

namespace PJ_WEBAPP001
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerificaSession());
            
        }
    }
}
