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
    public class IndexController : Controller
    {
        private String redirectUri = "http://localhost:54142/auth-endpoint";
        private Random random = new Random();

        public ActionResult Index()
        {
            ReniecIdaasClient oReniecClient = getClient();

            Session["state"] = oReniecClient.state;

            ViewData["url"] = oReniecClient.getLoginUrl();

            return View();
        }

        public async Task<ActionResult> Endpoint(String code, String error, String state)
        {
            if (error != null || code == null)
            {
                return Redirect("/");
            }

            if (!Session["state"].Equals(state))
            {
                return Redirect("/");
            }

            System.Net.ServicePointManager.Expect100Continue = false;

            ReniecIdaasClient oReniecClient = getClient();
            TokenResponse tokenResponse = await oReniecClient.getTokens(code);

            if (tokenResponse == null)
            {
                return Redirect("/");
            }

            User oUser = await oReniecClient.getUserInfo(tokenResponse.accessToken);

            if (oUser == null)
            {
                return Redirect("/");
            }

            return View(oUser);
        }

        private ReniecIdaasClient getClient()
        {
            String jsonConfig = Server.MapPath("~/App_Data/reniec_idaas.json");
            ReniecIdaasClient oReniecClient = new ReniecIdaasClient(jsonConfig);

            oReniecClient.acr = Constants.ACR_ONE_FACTOR;
            oReniecClient.lstScopes.Add(Constants.SCOPE_PROFILE);
            oReniecClient.lstScopes.Add(Constants.SCOPE_EMAIL);
            oReniecClient.lstScopes.Add(Constants.SCOPE_PHONE);
            oReniecClient.redirectUri = redirectUri;
            oReniecClient.state = RandomString(10);

            return oReniecClient;
        }

        private String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new String(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}