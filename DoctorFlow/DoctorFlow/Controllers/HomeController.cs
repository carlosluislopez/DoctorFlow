using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["USERID"] == null || Session["USERID"].ToString() == "")
            {
                Session.Add("USERNAME", string.Empty);
                Session.Add("USERID", -1);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}