using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorFlow.Models.UserModels;
using RestSharp;

namespace DoctorFlow.Controllers
{
    public class PasswordRecoveryController : Controller
    {
        // GET: PasswordRecovery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UserPasswordRecoveryModel userPasswordRecoveryModel)
        {
            SendSimpleMessage(userPasswordRecoveryModel.Email, "Stub");
            return RedirectToAction("Create", "Login");
        }

        public static IRestResponse SendSimpleMessage(string email, string message)
        {
           /* RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-5sbcxpwm9avrbeds-35y2i5hmda4y8k1");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "sandbox37840.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Doctor Flow");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Recuperacion de contraseña");
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);*/

            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator = new HttpBasicAuthenticator(
                "api", "key-5sbcxpwm9avrbeds-35y2i5hmda4y8k1");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "sandbox37840.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "drflow <Drflow@sandbox37840.mailgun.org>");
            request.AddParameter("to", "immac.gm@gmail.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomeness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}