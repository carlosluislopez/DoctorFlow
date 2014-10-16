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
            ViewBag.SuccessAlert = TempData["RegisterSuccess"];
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var userAccount = new UserRepository();
                var user = userAccount.Login(loginModel.EmailOrUserName, loginModel.Password);

                if (user == null)
                {
                    ViewBag.Errors = new[]
                    {
                        "•Esta combinacion de Nombre/Correo y Contraseña no existe, verifique ambos e intente de nuevo."
                    };
                    return View(loginModel);
                }
                Session.Add("USERNAME", user.Name);
                Session.Add("USERID", user.Id);
                
                if(userAccount.isDoctor(user.Id))
                    Session.Add("ISDOCTOR", "1");
                
                return RedirectToAction("Details", "Profile");
            }
            return View(loginModel);
        }
        public ActionResult Logout()
        {
            Session["USERNAME"] = string.Empty;
            Session.Add("USERID", -1);
            Session.Add("ISDOCTOR", 0);
            return RedirectToAction("Index", "Home"); 
        }
    }
}
