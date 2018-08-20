using idaas_sdk_csharp;
using idaas_sdk_csharp.common;
using idaas_sdk_csharp.dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (http://miguelpazo.com)
 */
namespace integration_csharp_example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User oUser = (User)Session["oUser"];

            return View(oUser);
        }
    }
}