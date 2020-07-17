﻿using idaas_sdk_csharp;
using idaas_sdk_csharp.common;
using System;
using System.Linq;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (https://miguelpazo.com)
 */
namespace integration_csharp_example.Controllers
{
    public class ParentController : Controller
    {
        protected String baseUrl = "http://localhost:54142";
        protected Random random = new Random();

        protected ReniecIdaasClient getClient()
        {
            String jsonConfig = Server.MapPath("~/App_Data/reniec_idaas.json");
            ReniecIdaasClient oReniecClient = new ReniecIdaasClient(jsonConfig);

            oReniecClient.acr = Constants.ACR_PKI_DNIE;
            oReniecClient.lstScopes.Add(Constants.SCOPE_PROFILE);
            oReniecClient.redirectUri = baseUrl + "/auth-endpoint";
            oReniecClient.state = RandomString(10);

            return oReniecClient;
        }

        protected String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new String(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}