using System.Web;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (http://miguelpazo.com)
 */
namespace integration_csharp_example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
