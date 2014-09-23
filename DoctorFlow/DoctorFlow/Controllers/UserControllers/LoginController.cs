using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows.Forms;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;
using Microsoft.JScript;

namespace DoctorFlow.Controllers.UserControllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserLoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = new[]
                    {
                        "•Algunos campos no son validos!"
                    };
                return View(loginModel);
            }
            var userAccount = new UserRepository();
            var user = userAccount.Login(loginModel.EmailOrUserName, loginModel.Password);


            if (user == null)
            {
                ViewBag.Errors = new[]
                {
                    "•El usuario no existe!"
                };
                return View(loginModel);
            }
            Session.Add("USERNAME", user.Name);
            Session.Add("USERID", user.Id);
            return RedirectToAction("Details", "Profile");
        }
        public ActionResult Logout()
        {
            Session["USERNAME"] = string.Empty;
            Session.Add("USERID", -1);
            return RedirectToAction("Index", "Home"); 
        }
    }
}
